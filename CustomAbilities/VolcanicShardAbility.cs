﻿using System;
using Characters;
using Characters.Abilities;
using Characters.Gear.Synergy.Inscriptions;
using Characters.Player;
using Services;
using Singletons;
using UnityEngine;

namespace VoiceOfTheCommunity.CustomAbilities;

[Serializable]
public class VolcanicShardAbility : Ability, ICloneable
{
    public class Instance : AbilityInstance<VolcanicShardAbility>
    {
        private EnumArray<Inscription.Key, Inscription> inscriptions;
        private Inventory _inventory;

        public override int iconStacks => ArsonInscriptionCount();

        public int ArsonInscriptionCount()
        {
            foreach (var inscription in inscriptions)
            {
                if (inscription.key == Inscription.Key.Arson)
                {
                    return inscription.count;
                }
            }
            return 0;
        }

        public Instance(Character owner, VolcanicShardAbility ability) : base(owner, ability)
        {
            _inventory = owner.playerComponents.inventory;
            inscriptions = owner.playerComponents.inventory.synergy.inscriptions;
        }

        public override void OnAttach()
        {
            RefreshArsonInscriptionCount();
            owner.status.durationMultiplier[CharacterStatus.Kind.Burn].AddOrUpdate(this, -0.2f);
            _inventory.onUpdatedKeywordCounts += RefreshArsonInscriptionCount;
            owner.onGiveDamage.Add(0, new GiveDamageDelegate(AmplifyBurnDamage));
        }

        public override void OnDetach()
        {
            owner.status.durationMultiplier[CharacterStatus.Kind.Burn].Remove(this);
            _inventory.onUpdatedKeywordCounts -= RefreshArsonInscriptionCount;
            owner.onGiveDamage.Remove(new GiveDamageDelegate(AmplifyBurnDamage));
        }

        private void RefreshArsonInscriptionCount()
        {
        }

        private bool AmplifyBurnDamage(ITarget target, ref Damage damage)
        {
            if (target == null || target.character == null || target.character.status == null)
            {
                return false;
            }
            if (damage.key == "burn") damage.percentMultiplier += 0.2;
            if (target.character.status.IsApplying(CharacterStatus.Kind.Burn)) damage.percentMultiplier *= 1 + 0.05 * ArsonInscriptionCount();
            return false;
        }
    }

    public override IAbilityInstance CreateInstance(Character owner)
    {
        return new Instance(owner, this);
    }

    public object Clone()
    {
        return new VolcanicShardAbility()
        {
            _defaultIcon = _defaultIcon,
        };
    }
}
