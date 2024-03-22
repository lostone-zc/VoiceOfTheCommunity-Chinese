﻿using System.Collections.Generic;
using System.Linq;
using Characters;
using Characters.Abilities;
using Characters.Gear.Synergy.Inscriptions;
using VoiceOfTheCommunity.CustomAbilities;
using UnityEngine.AddressableAssets;
using static Characters.Damage;
using static Characters.CharacterStatus;
using Characters.Abilities.CharacterStat;
using Characters.Gear;
using VoiceOfTheCommunity.CustomBehaviors;

namespace VoiceOfTheCommunity;

public class CustomItems
{
    public static readonly List<CustomItemReference> Items = InitializeItems();

    /**
     * TODO
     * 
     * Remove phys atk from Flask of Botulism - done
     * Put the CORRECT files for the Heavy-Duty Carleon Helmet - done
     * Remove amp from Goddess's Chalice - done
     * Mana Accelerator 15% -> 10% - done
     * Accursed Sabre 20% -> 10% - done
     * Frozen Spear 2% -> 10% - done
     * Frozen Spear evolution 300 -> 250 - done
     * Resprite Winged Spear line - done
     * Winged Sword -> Solar-Winged Sword - done
     * Winged Insignia -> Lunar-Winged Insignia - done
     * Add item list - done
     * Renamed Behavior file name for Tainted Red Scarf - done
     * Resprite Dream Catcher - done
     * Change description of Beginner's Lance - done
     * Omen: Last Dawn becomes obtainable in the Dev Menu mod - done
     */

    private static List<CustomItemReference> InitializeItems()
    {
        List<CustomItemReference> items = new();
        {
            var item = new CustomItemReference();
            item.name = "VaseOfTheFallen";
            item.rarity = Rarity.Unique;

            // EN: Vase of the Fallen
            // KR: 영혼이 담긴 도자기
            // ZH: 堕落者之瓶
            item.itemName = "堕落者之瓶";

            // EN: Increases <color=#F25D1C>Physical Attack</color> and <color=#1787D8>Magic Attack</color> by 5% per enemy killed (stacks up to 200% and 1/2 of total charge is lost when hit).\n
            // Attacking an enemy within 1 second of taking from a hit restores half of the charge lost from the hit (Cooldown: 3 seconds).

            // KR: 처치한 적의 수에 비례하여 <color=#F25D1C>물리공격력</color> 및 <color=#1787D8>마법공격력</color>이 5% 증가합니다 (최대 200% 증가, 피격시 증가치의 절반이 사라집니다).\n
            // 피격 후 1초 내로 적 공격 시 감소한 증가치의 절반을 되돌려 받습니다 (쿨타임: 3초).

            // ZH: 杀死一个敌人增加5%<color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>，（最多200%，受击减半），\n
            // 1秒内反击时回复面板（冷却：3秒）。

            item.itemDescription = "杀死一个敌人增加5%<color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>，（最多200%，受击减半），\n"
                                 + "1秒内反击时回复面板（冷却：3秒）。";

            // EN: Souls of the Eastern Kingdom's fallen warriors shall aid you in battle.
            // KR: 장렬히 전사했던 동쪽 왕국의 병사들의 혼이 담긴 영물
            // ZH: 东方英灵不散，同汝一共御敌。
            item.itemLore = "东方英灵不散，同汝一共御敌。";

            item.prefabKeyword1 = Inscription.Key.Heritage;
            item.prefabKeyword2 = Inscription.Key.Revenge;

            VaseOfTheFallenAbility ability = new()
            {
                _revengeTimeout = 1.0f,
                _revengeCooldown = 3.0f,
                _maxStack = 40,
                _statPerStack = new Stat.Values(
                [
                    new(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 0.05),
                    new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.05),
                ])
            };

            item.abilities = [
                ability
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "BrokenHeart";
            item.rarity = Rarity.Unique;

            // EN: Broken Heart
            // KR: 찢어진 심장
            // ZH: 空虚容器
            item.itemName = "空虚容器";

            // EN: Increases <color=#1787D8>Magic Attack</color> by 20%.\n
            // Increases Quintessence cooldown speed by 30%.\n
            // Amplifies Quintessence damage by 15%.\n
            // If the 'Succubus' Quintessence is in your possession, this item turns into 'Lustful Heart'.

            // KR: <color=#1787D8>마법공격력</color>이 20% 증가합니다.\n
            // 정수 쿨다운 속도가 30% 증가합니다.\n
            // 적에게 정수로 입히는 데미지가 15% 증폭됩니다.\n
            // '서큐버스' 정수 소지 시 이 아이템은 '색욕의 심장'으로 변합니다.

            // ZH: <color=#1787D8>魔法攻击力</color>增加20%，\n
            // 精华冷却速度增加30%，\n
            // 精华伤害增幅15%，\n
            // 当你拥有精华“魅魔”时，该物品进化。

            item.itemDescription = "<color=#1787D8>魔法攻击力</color>增加20%，\n"
                                 + "精华冷却速度增加30%，\n"
                                 + "精华伤害增幅15%，\n"
                                 + "当你拥有精华“魅魔”时，该物品进化。";

            // EN: Some poor being must have their heart torn both metaphorically and literally.
            // KR: 딱한 것, 심장이 은유적으로도 물리적으로도 찢어지다니.
            // ZH: 一些穷汉子的心确实是被踩烂了，生理上或心理上。
            item.itemLore = "一些穷汉子的心确实是被踩烂了，生理上或心理上。";

            item.prefabKeyword1 = Inscription.Key.Heritage;
            item.prefabKeyword2 = Inscription.Key.Wisdom;

            item.stats = new Stat.Values(
            [
                new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.2),
                new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.EssenceCooldownSpeed, 0.3),
            ]);

            ModifyDamage quintDamage = new();

            quintDamage._attackTypes = new();
            quintDamage._attackTypes[MotionType.Quintessence] = true;

            quintDamage._damageTypes = new([true, true, true, true, true]);

            quintDamage._damagePercent = 1.15f;

            item.abilities = [
                quintDamage
            ];

            item.extraComponents = [
                typeof(BrokenHeartEvolveBehavior),
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "BrokenHeart_2";
            item.rarity = Rarity.Legendary;

            item.obtainable = false;

            // EN: Lustful Heart
            // KR: 색욕의 심장
            // ZH: 欲孽之心
            item.itemName = "欲孽之心";

            // EN: Amplifies <color=#1787D8>Magic Attack</color> by 20%.\n
            // Increases Quintessence cooldown speed by 60%.\n
            // Amplifies Quintessence damage by 30%.\n

            // KR: <color=#1787D8>마법공격력</color>이 20% 증폭됩니다.\n
            // 정수 쿨다운 속도가 60% 증가합니다.\n
            // 적에게 정수로 입히는 데미지가 30% 증폭됩니다.\n

            // ZH: <color=#1787D8>魔法攻击力</color>增幅20%，\n
            // 精华冷却速度增加60%，\n
            // 精华伤害增幅30%。

            item.itemDescription = "<color=#1787D8>魔法攻击力</color>增幅20%，\n"
                                 + "精华冷却速度增加60%，\n"
                                 + "精华伤害增幅30%。";

            // EN: Given to the greatest Incubus or Succubus directly from the demon prince of lust, Asmodeus.
            // KR: 색욕의 마신 아스모데우스로부터 가장 위대한 인큐버스 혹은 서큐버스에게 하사된 증표
            // ZH: 由欲孽王子阿斯莫德斯将其授予最棒的淫妖或者魅魔。（男魅魔叫淫妖）
            item.itemLore = "由欲孽王子阿斯莫德斯将其授予最棒的淫妖或者魅魔。（男魅魔叫淫妖）";

            item.prefabKeyword1 = Inscription.Key.Heritage;
            item.prefabKeyword2 = Inscription.Key.Wisdom;

            item.stats = new Stat.Values(
            [
                new Stat.Value(Stat.Category.Percent, Stat.Kind.MagicAttackDamage, 1.2),
                new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.EssenceCooldownSpeed, 0.6),
            ]);

            ModifyDamage quintDamage = new();

            quintDamage._attackTypes = new();
            quintDamage._attackTypes[MotionType.Quintessence] = true;

            quintDamage._damageTypes = new([true, true, true, true, true]);

            quintDamage._damagePercent = 1.3f;

            item.abilities = [
                quintDamage
            ];

            item.forbiddenDrops = new[] { "Custom-BrokenHeart" };

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "SmallTwig";
            item.rarity = Rarity.Legendary;

            // EN: Small Twig
            // KR: 작은 나뭇가지
            // ZH: 小树枝
            item.itemName = "小树枝";

            // EN: Amplifies <color=#F25D1C>Physical Attack</color> and <color=#1787D8>Magic Attack</color> by 15%.\n
            // Increases skill cooldown speed and skill casting speed by 30%.\n
            // Increases Crit Rate and Crit Damage by 10%.\n
            // All effects double and Amplifies damage dealt to enemies by 20% when "Skul" or "Hero Little Bone" is your current active skull.

            // KR: <color=#F25D1C>물리공격력</color> 및 <color=#1787D8>마법공격력</color>이 15% 증폭됩니다.\n
            // 스킬 쿨다운 속도 및 스킬 시전 속도가 30% 증가합니다.\n
            // 치명타 확률 및 치명타 피해가 10% 증가합니다.\n
            // "스컬" 혹은 "용사 리틀본" 스컬을 사용 중일 시 이 아이템의 모든 스탯 증가치가 두배가 되며 적에게 입히는 데미지가 20% 증폭됩니다.

            // ZH: <color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>增幅15%，\n
            // 技能冷却速度增加30%，技能释放速度增加30%，\n
            // 暴击率增加10%，暴击伤害增加10%，\n
            // 如果你使用的是初始骨那么以上效果翻倍，造成伤害增幅20%。

            item.itemDescription = "<color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>增幅15%，\n"
                                 + "技能冷却速度增加30%，技能释放速度增加30%，\n"
                                 + "暴击率增加10%，暴击伤害增加10%，\n"
                                 + "如果你使用的是初始骨那么以上效果翻倍，造成伤害增幅20%。";

            // EN: A really cool looking twig, but for some reason I feel sad...
            // KR: 정말 멋있어 보이는 나뭇가지일 터인데, 왜 볼 때 마다 슬퍼지는 걸까...
            // ZH: 嘿，我找到一根完美的棍子，但为什么感觉这么伤感呢...
            item.itemLore = "嘿，我找到一根完美的棍子，但为什么感觉这么伤感呢...";

            item.prefabKeyword1 = Inscription.Key.Duel;
            item.prefabKeyword2 = Inscription.Key.Strike;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.Percent, Stat.Kind.PhysicalAttackDamage, 1.15),
                new(Stat.Category.Percent, Stat.Kind.MagicAttackDamage, 1.15),
                new(Stat.Category.PercentPoint, Stat.Kind.SkillCooldownSpeed, 0.3),
                new(Stat.Category.PercentPoint, Stat.Kind.SkillAttackSpeed, 0.3),
                new(Stat.Category.PercentPoint, Stat.Kind.CriticalChance, 0.1),
                new(Stat.Category.PercentPoint, Stat.Kind.CriticalDamage, 0.1),
            ]);

            item.extraComponents = [
                typeof(SmallTwigEvolveBehavior),
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "SmallTwig_2";
            item.rarity = Rarity.Legendary;

            item.obtainable = false;

            // EN: Small Twig
            // KR: 작은 나뭇가지
            // ZH: 小树枝
            item.itemName = "小树枝";

            // EN: Amplifies <color=#F25D1C>Physical Attack</color> and <color=#1787D8>Magic Attack</color> by 15%.\n
            // Increases skill cooldown speed and skill casting speed by 30%.\n
            // Increases Crit Rate and Crit Damage by 10%.\n
            // All effects double and amplifies damage dealt to enemies by 20% when 'Skul' or 'Hero Little Bone' is your current active skull.

            // KR: <color=#F25D1C>물리공격력</color> 및 <color=#1787D8>마법공격력</color>이 15% 증폭됩니다.\n
            // 스킬 쿨다운 속도 및 스킬 시전 속도가 30% 증가합니다.\n
            // 치명타 확률 및 치명타 피해가 10% 증가합니다.\n
            // '스컬' 혹은 '용사 리틀본' 스컬을 사용 중일 시 이 아이템의 모든 스탯 증가치가 두배가 되며 적에게 입히는 데미지가 20% 증폭됩니다.

            // ZH: <color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>增幅15%，\n
            // 技能冷却速度增加30%，技能释放速度增加30%，\n
            // 暴击率增加10%，暴击伤害增加10%，\n
            // 如果你使用的是初始骨那么以上效果翻倍，造成伤害增幅20%。

            item.itemDescription = "<color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>增幅15%，\n"
                                 + "技能冷却速度增加30%，技能释放速度增加30%，\n"
                                 + "暴击率增加10%，暴击伤害增加10%，\n"
                                 + "如果你使用的是初始骨那么以上效果翻倍，造成伤害增幅20%。";

            // EN: A really cool looking twig, but for some reason I feel sad...
            // KR: 정말 멋있어 보이는 나뭇가지일 터인데, 왜 볼 때 마다 슬퍼지는 걸까...
            // ZH: 嘿，我找到一根完美的棍子，但为什么感觉这么伤感呢...
            item.itemLore = "嘿，我找到一根完美的棍子，但为什么感觉这么伤感呢...";

            item.prefabKeyword1 = Inscription.Key.Duel;
            item.prefabKeyword2 = Inscription.Key.Strike;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.Percent, Stat.Kind.PhysicalAttackDamage, 1.3),
                new(Stat.Category.Percent, Stat.Kind.MagicAttackDamage, 1.3),
                new(Stat.Category.PercentPoint, Stat.Kind.SkillCooldownSpeed, 0.6),
                new(Stat.Category.PercentPoint, Stat.Kind.SkillAttackSpeed, 0.6),
                new(Stat.Category.PercentPoint, Stat.Kind.CriticalChance, 0.2),
                new(Stat.Category.PercentPoint, Stat.Kind.CriticalDamage, 0.2),
            ]);

            ModifyDamage amplifyDamage = new();

            amplifyDamage._attackTypes = new([true, true, true, true, true, true, true, true, true]);

            amplifyDamage._damageTypes = new([true, true, true, true, true]);

            amplifyDamage._damagePercent = 1.2f;

            item.abilities = [
                amplifyDamage
            ];

            item.extraComponents = [
                typeof(SmallTwigRevertBehavior),
            ];

            item.forbiddenDrops = new[] { "Custom-SmallTwig" };

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "VolcanicShard";
            item.rarity = Rarity.Legendary;

            // EN: Volcanic Shard
            // KR: 화산의 일각
            // ZH: 火山岩锋
            item.itemName = "火山岩锋";

            // EN: Increases <color=#1787D8>Magic Attack</color> by 100%.\n
            // Normal attacks and skills have a 20% chance to inflict Burn.\n
            // Amplifies damage dealt to Burning enemies by 25%.\n
            // Burn duration decreases by 10% for each Arson inscription in possession.

            // KR: <color=#1787D8>마법공격력</color>이 100% 증가합니다.\n
            // 적 공격 시 20% 확률로 화상을 부여합니다.\n
            // 적에게 화상으로 입히는 데미지가 25% 증폭됩니다.\n
            // 가지고 있는 방화 각인에 비례하여 화상의 지속시간이 10%씩 감소합니다.

            // ZH: <color=#1787D8>魔法攻击力</color>增加100%，\n
            // 普攻与技能有20%概率给予火伤，\n
            // 对火伤状态敌人造成伤害增幅25%，\n
            // 每装备一个放火刻印，火焰燃烧的伤害间隔缩短10%。

            item.itemDescription = "<color=#1787D8>魔法攻击力</color>增加100%，\n"
                                         + "普攻与技能有20%概率给予火伤，\n"
                                         + "对火伤状态敌人造成伤害增幅25%，\n"
                                         + "每装备一个放火刻印，火焰燃烧的伤害间隔缩短10%。";

            // EN: Rumored to be created from the Black Rock Volcano when erupting, this giant blade is the hottest flaming sword.
            // KR: 전설의 흑요석 화산의 폭발에서 만들어졌다고 전해진, 세상에서 가장 뜨거운 칼날
            // ZH: 岩浆所熔，黑岩所锻，山灰漫天，神剑出世。
            item.itemLore = "岩浆所熔，黑岩所锻，山灰漫天，神剑出世。";

            item.prefabKeyword1 = Inscription.Key.Execution;
            item.prefabKeyword2 = Inscription.Key.Arson;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 1),
            ]);

            var applyStatus = new ApplyStatusOnGaveDamage();
            var status = Kind.Burn;
            applyStatus._cooldownTime = 0.1f;
            applyStatus._chance = 20;
            applyStatus._attackTypes = new();
            applyStatus._attackTypes[MotionType.Basic] = true;
            applyStatus._attackTypes[MotionType.Skill] = true;

            applyStatus._types = new();
            applyStatus._types[AttackType.Melee] = true;
            applyStatus._types[AttackType.Ranged] = true;
            applyStatus._types[AttackType.Projectile] = true;

            applyStatus._status = new ApplyInfo(status);

            item.abilities = [
                new VolcanicShardAbility(),
                applyStatus,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "RustyChalice";
            item.rarity = Rarity.Unique;

            // EN: Rusty Chalice
            // KR: 녹슨 성배
            // ZH: 纳垢圣杯
            item.itemName = "纳垢圣杯";

            // EN: Increases swap cooldown speed by 15%.\n
            // Upon hitting enemies with a swap skill 150 times, this item transforms into 'Goddess's Chalice.'

            // KR: 교대 쿨다운 속도가 15% 증가?니다.\n
            // 적에게 교대스킬로 데미지를 150번 줄 시 해당 아이템은 '여신의 성배'로 변합니다.

            // ZH: 替换冷却速度增加15%，\n
            // 替换技能击中150敌人时进化。

            item.itemDescription = "替换冷却速度增加15%，\n"
                                 + "替换技能击中150敌人时进化。";

            // EN: This thing? I found it at a pawn shop and it seemed interesting
            // KR: 아 이거? 암시장에서 예뻐 보이길래 샀는데, 어때?
            // ZH: 这玩意？我在当铺看见的，感觉有点意思。
            item.itemLore = "这玩意？我在当铺看见的，感觉有点意思。";

            item.prefabKeyword1 = Inscription.Key.Mutation;
            item.prefabKeyword2 = Inscription.Key.Mystery;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.SwapCooldownSpeed, 0.15),
            ]);

            item.abilities = [
                new RustyChaliceAbility(),
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "RustyChalice_2";
            item.rarity = Rarity.Legendary;

            item.obtainable = false;

            // EN: Goddess's Chalice
            // KR: 여신의 성배
            // ZH: 女神圣杯
            item.itemName = "女神圣杯";

            // EN: Increases swap cooldown speed by 40%.\n
            // Swapping increases <color=#F25D1C>Physical Attack</color> and <color=#1787D8>Magic Attack</color> by 10% for 6 seconds (maximum 40%).\n
            // At maximum stacks, swap cooldown speed is increased by 25%.

            // KR: 교대 쿨다운 속도가 40% 증가?니다.\n
            // 교대 시 6초 동안 <color=#F25D1C>물리공격력</color> 및 <color=#1787D8>마법공격력</color>이 10% 증가합니다 (최대 60%).\n
            // 공격력 증가치가 최대일 시, 교대 쿨다운 속도가 25% 증가합니다.

            // ZH: 替换冷却速度增加40%，\n
            // 6秒内替换时增加10%<color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>（最多40%），\n
            // 满层后增加25%替换冷却速度。

            item.itemDescription = "替换冷却速度增加40%，\n"
                                 + "6秒内替换时增加10%<color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>（最多40%），\n"
                                 + "满层后增加25%替换冷却速度。";

            // EN: Chalice used by Leonia herself that seems to never run dry
            // KR: 여신 레오니아 본인께서 쓰시던 절대 비워지지 않는 성배
            // ZH: 雷欧尼亚女神用过的杯子，似乎不会干涸。
            item.itemLore = "雷欧尼亚女神用过的杯子，似乎不会干涸。";

            item.prefabKeyword1 = Inscription.Key.Mutation;
            item.prefabKeyword2 = Inscription.Key.Mystery;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.SwapCooldownSpeed, 0.4),
            ]);

            GoddesssChaliceAbility goddesssChaliceAbility = new()
            {
                _timeout = 6.0f,
                _maxStack = 4,
                _statPerStack = new Stat.Values(
                [
                    new(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 0.1),
                    new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.1),
                ]),
                _maxStackStats = new Stat.Values(
                [
                    new(Stat.Category.PercentPoint, Stat.Kind.SwapCooldownSpeed, 0.25),
                ]),
            };

            item.abilities = [
                goddesssChaliceAbility,
            ];

            item.forbiddenDrops = new[] { "Custom-RustyChalice" };

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "FlaskOfBotulism";
            item.rarity = Rarity.Unique;

            item.gearTag = Gear.Tag.Omen;
            item.obtainable = false;

            // EN: Omen: Flask of Botulism
            // KR: 흉조: 역병의 플라스크
            // ZH: 预兆：病毒样本
            item.itemName = "预兆：病毒样本";

            // EN: The interval between poison damage ticks is further decreased.

            // KR: 중독 데미지가 발생하는 간격이 더욱 줄어듭니다.

            // ZH: 进一步缩短中毒伤害的伤害间隔。

            item.itemDescription = "进一步缩短中毒伤害的伤害间隔。"

            // EN: Only the mad and cruel would consider using this as a weapon.
            // KR: 정말 미치지 않고서야 이걸 무기로 쓰는 일은 없을 것이다.
            // ZH: 疯子和战争狂人才会把它当作武器。（byd细菌战是吧）
            item.itemLore = "疯子和战争狂人才会把它当作武器。（byd细菌战是吧）";

            item.prefabKeyword1 = Inscription.Key.Omen;
            item.prefabKeyword2 = Inscription.Key.Poisoning;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.Constant, Stat.Kind.PoisonTickFrequency, 0.1),
            ]);

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "CorruptedSymbol";
            item.rarity = Rarity.Unique;

            item.gearTag = Gear.Tag.Omen;
            item.obtainable = false;

            // EN: Omen: Corrupted Symbol
            // KR: 흉조: 오염된 상징
            // ZH: 预兆：堕魔符号
            item.itemName = "预兆：堕魔符号";

            // EN: For every Spoils inscription owned, increase <color=#F25D1C>Physical Attack</color> and <color=#1787D8>Magic Attack</color> by 80%.

            // KR: 보유하고 있는 '칼레온' 아이템 1개당 <color=#F25D1C>물리공격력</color> 및 <color=#1787D8>마법공격력</color>이 80% 증가합니다.

            // ZH: 每个战利品刻印增加80%<color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>。

            item.itemDescription = "每个战利品刻印增加80%<color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>。";

            // EN: Where's your god now?
            // KR: 자, 이제 네 신은 어딨지?
            // ZH: 汝之女神何在？
            item.itemLore = "汝之女神何在？";

            item.prefabKeyword1 = Inscription.Key.Omen;
            item.prefabKeyword2 = Inscription.Key.Spoils;

            CorruptedSymbolAbility ability = new()
            {
                _statPerStack = new Stat.Values(
                [
                    new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 0.8),
                    new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.8),
                ])
            };

            item.abilities = [
                ability,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "TaintedFinger";
            item.rarity = Rarity.Legendary;

            // EN: Tainted Finger
            // KR: 침식된 손가락
            // ZH: 灵巧的手
            item.itemName = "灵巧的手";

            // EN: Skill damage dealt to enemies is amplified by 30%.\n
            // Increases <color=#1787D8>Magic Attack</color> by 60%.

            // KR: 적에게 스킬로 입히는 데미지가 30% 증폭됩니다.\n
            // <color=#1787D8>마법공격력</color>이 60% 증가합니다.

            // ZH: 技能伤害增幅30%，\n
            // <color=#1787D8>魔法攻击力</color>增加60%。

            item.itemDescription = "技能伤害增幅30%，\n"
                                 + "<color=#1787D8>魔法攻击力</color>增加60%。";

            // EN: A finger from a god tainted by dark quartz
            // KR: 검은 마석에 의해 침식된 신의 손가락
            // ZH: 魔石腐蚀了神体，手指从中脱落。
            item.itemLore = "魔石腐蚀了神体，手指从中脱落。";

            item.prefabKeyword1 = Inscription.Key.Artifact;
            item.prefabKeyword2 = Inscription.Key.Masterpiece;

            ModifyDamage amplifySkillDamage = new();

            amplifySkillDamage._attackTypes = new();
            amplifySkillDamage._attackTypes[MotionType.Skill] = true;

            amplifySkillDamage._damageTypes = new([true, true, true, true, true]);

            amplifySkillDamage._damagePercent = 1.3f;

            item.abilities = [
                amplifySkillDamage,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "TaintedFinger_2";
            item.rarity = Rarity.Legendary;

            item.obtainable = false;

            // EN: Tainted Finger
            // KR: 침식된 손가락
            // ZH: 天才巧手
            item.itemName = "天才巧手";

            // EN: Skill damage dealt to enemies is amplified by 30%.\n
            // Increases <color=#1787D8>Magic Attack</color> by 60%.\n
            // If the item 'Grace of Leonia' is in your possession, this item turns into 'Corrupted God's Hand'.

            // KR: 적에게 스킬로 입히는 데미지가 30% 증폭됩니다.\n
            // <color=#1787D8>마법공격력</color>이 60% 증가합니다.\n
            // 현재 '레오니아의 은총' 아이템을 소지하고 있으면 해당 아이템은 '침식된 신의 손' 으로 변합니다.

            // ZH: 技能伤害增幅30%，\n
            // <color=#1787D8>魔法攻击力</color>增加60%，\n
            // 当你拥有“雷欧尼亚的恩宠”时，合成为“腐朽的神之手”。

            item.itemDescription = "技能伤害增幅30%，\n"
                                 + "<color=#1787D8>魔法攻击力</color>增加60%，\n"
                                 + "当你拥有“雷欧尼亚的恩宠”时，合成为“腐朽的神之手”。";

            // EN: Nothing happened. It seems like it needs something else.
            // KR: 아무 일도 일어나지 않았다. 뭔가 더 필요한 것 같다.
            // ZH: 无事发生（指杰作），看来还需要别的东西。
            item.itemLore = "无事发生（指杰作），看来还需要别的东西。";

            item.prefabKeyword1 = Inscription.Key.Artifact;
            item.prefabKeyword2 = Inscription.Key.Masterpiece;

            ModifyDamage amplifySkillDamage = new();

            amplifySkillDamage._attackTypes = new();
            amplifySkillDamage._attackTypes[MotionType.Skill] = true;

            amplifySkillDamage._damageTypes = new([true, true, true, true, true]);

            amplifySkillDamage._damagePercent = 1.3f;

            item.abilities = [
                amplifySkillDamage,
            ];

            item.extraComponents = [
                typeof(TaintedFingerEvolveBehavior),
            ];

            item.forbiddenDrops = new[] { "Custom-TaintedFinger" };

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "TaintedFinger_3";
            item.rarity = Rarity.Legendary;

            item.obtainable = false;

            // EN: Corrupted God's Hand
            // KR: 침식된 신의 손
            // ZH: 腐朽的神之手
            item.itemName = "腐朽的神之手";

            // EN: Skill damage dealt to enemies is amplified by 100%.\n
            // Increases <color=#1787D8>Magic Attack</color> by 100%.

            // KR: 적에게 스킬로 입히는 데미지가 100% 증폭됩니다.\n
            // <color=#1787D8>마법공격력</color>이 100% 증가합니다.

            // ZH: 技能伤害增幅100%，\n
            // <color=#1787D8>魔法攻击力</color>增加100%。

            item.itemDescription = "技能伤害增幅100%，\n"
                                 + "<color=#1787D8>魔法攻击力</color>增加100%。";

            // EN: A corrupt hand from Leonia's supposed god
            // KR: 레오니아로 추정되는 신의 침식된 손
            // KR: 雷欧尼亚之神因腐朽而脱落的手。
            item.itemLore = "雷欧尼亚之神因腐朽而脱落的手。";

            item.prefabKeyword1 = Inscription.Key.Artifact;
            item.prefabKeyword2 = Inscription.Key.Masterpiece;

            ModifyDamage amplifySkillDamage = new();

            amplifySkillDamage._attackTypes = new();
            amplifySkillDamage._attackTypes[MotionType.Skill] = true;

            amplifySkillDamage._damageTypes = new([true, true, true, true, true]);

            amplifySkillDamage._damagePercent = 2f;

            item.abilities = [
                amplifySkillDamage,
            ];

            item.forbiddenDrops = new[] { "Custom-TaintedFinger" };

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "DreamCatcher";
            item.rarity = Rarity.Legendary;

            // EN: Dream Catcher
            // KR: 드림캐처
            // ZH: 捕梦者
            item.itemName = "捕梦者";

            // EN: Increases <color=#1787D8>Magic Attack</color> by 50%.\n
            // <color=#1787D8>Magic damage</color> dealt to enemies under 40% HP is amplified by 25%.\n
            // <color=#1787D8>Magic Attack</color> increases by 8% each time an Omen or a Legendary item is destroyed.

            // KR: <color=#1787D8>마법공격력</color>이 50% 증가합니다.\n
            // 현재 체력이 40% 이하인 적에게 입히는 <color=#1787D8>마법데미지</color>가 25% 증폭됩니다.\n
            // 흉조 혹은 레전더리 등급을 가진 아이템을 파괴할 때마다 <color=#1787D8>마법공격력</color>이 8% 증가합니다.

            // ZH: <color=#1787D8>魔法攻击力</color>增加50%，\n
            // 对于血量在40%以下的敌人造成的<color=#1787D8>魔法伤害</color>增幅25%，\n
            // 每次分解预兆装备或者传说装备增加8%<color=#1787D8>魔法攻击力</color>。

            item.itemDescription = "<color=#1787D8>魔法攻击力</color>增加50%，\n"
                                 + "对于血量在40%以下的敌人造成的<color=#1787D8>魔法伤害</color>增幅25%，\n"
                                 + "每次分解预兆装备或者传说装备增加8%<color=#1787D8>魔法攻击力</color>。";

            // EN: Acceptance is the first step towards death.
            // KR: 수용하는 것은 죽음을 향한 첫 걸음이다.
            // ZH: 好梦多多来，噩梦快快走。
            item.itemLore = "好梦多多来，噩梦快快走。";

            item.prefabKeyword1 = Inscription.Key.Wisdom;
            item.prefabKeyword2 = Inscription.Key.Execution;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.5),
            ]);

            DreamCatcherAbility ability = new()
            {
                _statPerStack = new Stat.Values(
                [
                    new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.08),
                ])
            };

            item.abilities = [
                ability
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "BloodSoakedJavelin";
            item.rarity = Rarity.Rare;

            // EN: Blood-Soaked Javelin
            // KR: 피투성이 투창
            // ZH: 染血标枪
            item.itemName = "染血标枪";

            // EN: Increases Crit Damage by 20%.\n
            // Critical hits have a 10% chance to apply Wound (Cooldown: 0.5 seconds).

            // KR: 치명타 데미지가 20% 증가합니다.\n
            // 치명타 시 10% 확률로 적에게 상처를 부여합니다 (쿨타임: 0.5초).

            // ZH: 暴击伤害增加20%，\n
            // 暴击时有10%概率挂创伤。（冷却：0.5秒）

            item.itemDescription = "暴击伤害增加20%，\n"
                                 + "暴击时有10%概率挂创伤。";

            // EN: A javelin that always hits vital organs, and drains all the blood out of whichever one it hits
            // KR: 적의 심장을 정확히 노려 시체에 피 한방울 남기지 않는 투창
            // ZH: 刻有放血槽的标枪，杀人如杀猪。
            item.itemLore = "刻有放血槽的标枪，杀人如杀猪。";

            item.prefabKeyword1 = Inscription.Key.Misfortune;
            item.prefabKeyword2 = Inscription.Key.ExcessiveBleeding;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.CriticalDamage, 0.25),
            ]);

            item.abilities = [
                new BloodSoakedJavelinAbility(),
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "FrozenSpear";
            item.rarity = Rarity.Rare;

            // EN: Frozen Spear
            // KR: 얼음의 창
            // ZH: 冻魂
            item.itemName = "冻魂";

            // EN: Skills have a 10% chance to inflict Freeze.\n
            // Increases <color=#1787D8>Magic Attack</color> by 20%.\n
            // After applying freeze 250 times, this item turns into 'Spear of the Frozen Moon'.

            // KR: 적에게 스킬로 공격시 10% 확률로 빙결을 부여합니다.\n
            // <color=#1787D8>마법공격력</color>가 20% 증가합니다.\n
            // 적에게 빙결을 250번 부여할 시 해당 아이템은 '얼어붙은 달의 창'으로 변합니다.

            // ZH: 使用技能时有10%概率造成冰冻，\n
            // <color=#1787D8>魔法攻击力</color>增加20%，\n
            // 造成250次冰冻后物品进化。

            item.itemDescription = "使用技能时有10%概率造成冰冻，\n"
                                 + "<color=#1787D8>魔法攻击力</color>增加20%，\n"
                                 + "造成250次冰冻后物品进化。";

            // EN: A sealed weapon waiting the cold time to revealed it's true form.
            // KR: 해방의 혹한을 기다리는 봉인된 무기
            // ZH: 冻雪藏锋，以待破冰之时。
            item.itemLore = "冻雪藏锋，以待破冰之时。";

            item.prefabKeyword1 = Inscription.Key.AbsoluteZero;
            item.prefabKeyword2 = Inscription.Key.ManaCycle;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.2),
            ]);

            var applyStatus = new ApplyStatusOnGaveDamage();
            var status = Kind.Freeze;
            applyStatus._cooldownTime = 0.1f;
            applyStatus._chance = 10;
            applyStatus._attackTypes = new();
            applyStatus._attackTypes[MotionType.Skill] = true;

            applyStatus._types = new();
            applyStatus._types[AttackType.Melee] = true;
            applyStatus._types[AttackType.Ranged] = true;
            applyStatus._types[AttackType.Projectile] = true;

            applyStatus._status = new ApplyInfo(status);

            item.abilities = [
                new FrozenSpearAbility(),
                applyStatus,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "FrozenSpear_2";
            item.rarity = Rarity.Legendary;

            item.obtainable = false;

            // EN: Spear of the Frozen Moon
            // KR: 얼어붙은 달의 창
            // ZH: 寒魄
            item.itemName = "寒魄";

            // EN: Skills have a 15% chance to inflict Freeze.\n
            // Increases <color=#1787D8>Magic Attack</color> by 60%.\n
            // Attacking frozen enemies increases the number of hits to remove Freeze by 1.\n
            // Amplifies damage to frozen enemies by 25%.

            // KR: 적에게 스킬로 공격시 15% 확률로 빙결을 부여합니다.\n
            // <color=#1787D8>마법공격력</color>가 60% 증가합니다.\n
            // 빙결 상태의 적 공격 시 빙결이 해제되는데 필요한 타수가 1 증가합니다.\n
            // 빙결 상태의 적에게 입히는 데미지가 25% 증가합니다.

            // ZH: 技能有15%概率给予冰冻，\n
            // <color=#1787D8>魔法攻击力</color>增加60%，\n
            // 解除冰冻需要的打击次数增加1次，\n
            // 对冰冻状态敌人伤害增幅25%。

            item.itemDescription = "技能有15%概率给予冰冻，\n"
                                 + "<color=#1787D8>魔法攻击力</color>增加60%，\n"
                                 + "解除冰冻需要的打击次数增加1次，\n"
                                 + "对冰冻状态敌人伤害增幅25%。";

            // EN: When a battlefield turns into a permafrost, the weapon formely wielded by the ice beast Vaalfen appears. 
            // KR: 전장에 눈보라가 휘몰아칠 때, 얼음 괴수 발펜의 창이 나타날지니
            // ZH: 寒兽降临，战场化为冻土。
            item.itemLore = "寒兽降临，战场化为冻土。";

            item.prefabKeyword1 = Inscription.Key.AbsoluteZero;
            item.prefabKeyword2 = Inscription.Key.ManaCycle;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.6),
            ]);

            var applyStatus = new ApplyStatusOnGaveDamage();
            var status = Kind.Freeze;
            applyStatus._cooldownTime = 0.1f;
            applyStatus._chance = 15;
            applyStatus._attackTypes = new();
            applyStatus._attackTypes[MotionType.Skill] = true;

            applyStatus._types = new();
            applyStatus._types[AttackType.Melee] = true;
            applyStatus._types[AttackType.Ranged] = true;
            applyStatus._types[AttackType.Projectile] = true;

            applyStatus._status = new ApplyInfo(status);

            item.abilities = [
                new SpearOfTheFrozenMoonAbility(),
                applyStatus,
            ];

            item.forbiddenDrops = new[] { "Custom-FrozenSpear" };

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "CrossNecklace";
            item.rarity = Rarity.Common;

            // EN: Cross Necklace
            // KR: 십자 목걸이
            // ZH: 十字架项链
            item.itemName = "十字架项链";

            // EN: Recover 5 HP upon entering a map.

            // KR: 맵 입장 시 체력을 5 회복합니다.

            // ZH: 过图回5血。

            item.itemDescription = "过图回5血。";

            // EN: When all is lost, we turn to hope
            // KR: 모든 것을 잃었을 때, 희망을 바라볼지니
            // ZH: 无怨的接受只会迈向死亡。
            item.itemLore = "无怨的接受只会迈向死亡。";

            item.prefabKeyword1 = Inscription.Key.Relic;
            item.prefabKeyword2 = Inscription.Key.Heritage;

            item.abilities = [
                new CrossNecklaceAbility(),
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "RottenWings";
            item.rarity = Rarity.Rare;

            // EN: Rotten Wings
            // KR: 썩은 날개
            // ZH: 腐殖之翼
            item.itemName = "腐殖之翼";

            // EN: Crit Rate increases by 15% while in midair.\n
            // Your normal attacks have a 15% chance to inflict Poison.

            // KR: 공중에 있을 시 치명타 확률이 15% 증가합니다.\n
            // 적에게 기본공격 시 15% 확률로 중독을 부여합니다.

            // ZH: 在空中时增加15%暴击率，\n
            // 普攻时有15%概率给予中毒。

            item.itemDescription = "在空中时增加15%暴击率，\n"
                                 + "普攻时有15%概率给予中毒。";

            // EN: Wings of a zombie wyvern
            // KR: 좀비 와이번의 썩어 문드러진 날개
            // ZH: 僵尸飞龙的翅膀
            item.itemLore = "僵尸飞龙的翅膀";

            item.prefabKeyword1 = Inscription.Key.Poisoning;
            item.prefabKeyword2 = Inscription.Key.Soar;

            StatBonusByAirTime bonus = new();

            bonus._timeToMaxStat = 0.01f;
            bonus._remainTimeOnGround = 0.0f;
            bonus._maxStat = new Stat.Values(new Stat.Value[] {
                new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.CriticalChance, 0.15),
            });

            var applyStatus = new ApplyStatusOnGaveDamage();
            var status = Kind.Poison;
            applyStatus._cooldownTime = 0.1f;
            applyStatus._chance = 15;
            applyStatus._attackTypes = new();
            applyStatus._attackTypes[MotionType.Basic] = true;

            applyStatus._types = new();
            applyStatus._types[AttackType.Melee] = true;
            applyStatus._types[AttackType.Ranged] = true;
            applyStatus._types[AttackType.Projectile] = true;

            applyStatus._status = new ApplyInfo(status);

            item.abilities = [
                bonus,
                applyStatus,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "ShrinkingPotion";
            item.rarity = Rarity.Rare;

            // EN: Shrinking Potion
            // KR: 난쟁이 물약
            // ZH: 萎哥
            item.itemName = "萎哥";

            // EN: Decreases character size by 20%.\n
            // Increases Movement Speed by 15%.\n
            // Incoming damage increases by 10%.

            // KR: 캐릭터 크기가 20% 감소합니다.\n
            // 이동속도가 15% 증가합니다.\n
            // 받는 데미지가 10% 증가합니다.

            // ZH: 体型缩小20%，\n
            // 移动速度增加15%，\n
            // 受到伤害增加10%。

            item.itemDescription = "体型缩小20%，\n"
                                 + "移动速度增加15%，\n"
                                 + "受到伤害增加10%。";

            // EN: I think it was meant to be used on the enemies...
            // KR: 왠지 적에게 써야 할 것 같은데...
            // ZH: 俺寻思这玩意不应该是用给敌人的吗...
            item.itemLore = "俺寻思这玩意不应该是用给敌人的吗...";

            item.prefabKeyword1 = Inscription.Key.Mutation;
            item.prefabKeyword2 = Inscription.Key.Chase;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.Percent, Stat.Kind.CharacterSize, 0.8),
                new(Stat.Category.PercentPoint, Stat.Kind.MovementSpeed, 0.15),
                new(Stat.Category.Percent, Stat.Kind.TakingDamage, 1.1),
            ]);

            item.extraComponents = [
                typeof(ShrinkingPotionEvolveBehavior),
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "ShrinkingPotion_2";
            item.rarity = Rarity.Unique;

            item.obtainable = false;

            // EN: Unstable Size Potion
            // KR: 불안정한 크기 조정 물약
            // ZH: 薛定谔的药物
            item.itemName = "薛定谔的药物";

            // EN: Alters between the effects of 'Shrinking Potion' and 'Growing Potion' every 10 seconds.

            // KR: 10초 마다 '난쟁이 물약'과 '성장 물약'의 효과를 번갈아가며 적용합니다.

            // ZH: 每10秒在“萎哥”与“伟哥”之间切换。

            item.itemDescription = "每10秒在“萎哥”与“伟哥”之间切换。";

            // EN: Mixing those potions together was a bad idea
            // KR: 이 물약들을 섞는 것은 좋은 생각이 아니었다.
            // ZH: 早就说了把药剂都倒在一起不是个好主意。
            item.itemLore = "早就说了把药剂都倒在一起不是个好主意。";

            item.prefabKeyword1 = Inscription.Key.Mutation;
            item.prefabKeyword2 = Inscription.Key.Antique;

            UnstableSizePotionAbility ability = new()
            {
                _timeout = 10,
                _shrinkingStat = new Stat.Values(
                [
                    new(Stat.Category.Percent, Stat.Kind.CharacterSize, 0.8),
                    new(Stat.Category.PercentPoint, Stat.Kind.MovementSpeed, 0.15),
                    new(Stat.Category.Percent, Stat.Kind.TakingDamage, 1.1),
                ]),
                _growingStat = new Stat.Values([
                    new(Stat.Category.Percent, Stat.Kind.CharacterSize, 1.2),
                    new(Stat.Category.PercentPoint, Stat.Kind.MovementSpeed, -0.15),
                    new(Stat.Category.Percent, Stat.Kind.TakingDamage, 0.9),
                ])
            };

            item.abilities = [
                ability,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "GrowingPotion";
            item.rarity = Rarity.Rare;

            // EN: Growing Potion
            // KR: 성장 물약
            // ZH: 伟哥
            item.itemName = "伟哥";

            // EN: Increases character size by 20%.\n
            // Decreases Movement Speed by 15%.\n
            // Incoming damage decreases by 10%.

            // KR: 캐릭터 크기가 20% 증가합니다.\n
            // 이동속도가 15% 감소합니다.\n
            // 받는 데미지가 10% 감소합니다.

            // ZH: 体型变大20%，\n
            // 移动速度减少15%，\n
            // 减少受到的伤害10%。

            item.itemDescription = "体型变大20%，\n"
                                 + "移动速度减少15%，\n"
                                 + "减少受到的伤害10%。";

            // EN: Made from some weird size changing mushrooms deep within The Forest of Harmony
            // KR: 하모니아 숲 깊숙이 있는 수상한 버섯으로 만들어진 물약
            // ZH: 材料来自于和谐之森的一种可以改变体型的蘑菇。（byd蘑菇巨人是吧）
            item.itemLore = "材料来自于和谐之森的一种可以改变体型的蘑菇。（byd蘑菇巨人是吧）";

            item.prefabKeyword1 = Inscription.Key.Mutation;
            item.prefabKeyword2 = Inscription.Key.Fortress;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.Percent, Stat.Kind.CharacterSize, 1.2),
                new(Stat.Category.PercentPoint, Stat.Kind.MovementSpeed, -0.15),
                new(Stat.Category.Percent, Stat.Kind.TakingDamage, 0.9),
            ]);

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "ManaAccelerator";
            item.rarity = Rarity.Rare;

            // EN: Mana Accelerator
            // KR: 마나 가속기
            // ZH: 魔力加速器
            item.itemName = "魔力加速器";

            // EN: Skill casting speed increases by 10% for each Mana Cycle inscription in possession.

            // KR: 보유중인 마나순환 각인 1개당 스킬 시전 속도가 10% 증가합니다.

            // ZH: 每个魔力循环刻印增加10%技能释放速度。

            item.itemDescription = "每个魔力循环刻印增加10%技能释放速度。";

            // EN: In a last ditch effort, mages may turn to this device to overcharge their mana. Though the high stress on the mage's mana can often strip them of all magic.
            // KR: 마나를 극한까지 과부하시키는 마법사들의 최후의 수단.\n너무 강한 과부하는 사용자를 불구로 만들 수 있으니 조심해야 한다
            // ZH: 法师们搏命的道具，用以超负荷运行法力，虽然事后也会让法力完全消失。
            item.itemLore = "法师们搏命的道具，用以超负荷运行法力，虽然事后也会让法力完全消失。";

            item.prefabKeyword1 = Inscription.Key.Manatech;
            item.prefabKeyword2 = Inscription.Key.Artifact;

            ManaAcceleratorAbility ability = new()
            {
                _statPerStack = new Stat.Values(
                [
                    new(Stat.Category.PercentPoint, Stat.Kind.SkillAttackSpeed, 0.1),
                ])
            };

            item.abilities = [
                ability,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "BeginnersLance";
            item.rarity = Rarity.Common;

            // EN: Beginner's Lance
            // KR: 초보자용 창
            // ZH: 初学者长枪
            item.itemName = "初学者长枪";

            // EN: Increases <color=#F25D1C>Physical Attack</color> by 20%.\n
            // Damage dealt to enemies with a dash attack is amplified by 30%.

            // KR: <color=#F25D1C>물리공격력</color>이 20% 증가합니다.\n
            // 적에게 대쉬공격으로 입히는 데미지가 30% 증폭됩니다.

            // ZH: <color=#F25D1C>物理攻击力</color>增加20%，\n
            // 增幅30%疾驰伤害。

            item.itemDescription = "<color=#F25D1C>物理攻击力</color>增加20%，\n"
                                 + "增幅30%疾驰伤害。";

            // EN: Perfect! Now all I need is a noble steed...
            // KR: 완벽해! 이제 좋은 말만 있으면 되는데...
            // ZH: NICCCCE~现在我需要的只是一匹骏马了...
            item.itemLore = "NICCCCE~现在我需要的只是一匹骏马了...";

            item.prefabKeyword1 = Inscription.Key.Duel;
            item.prefabKeyword2 = Inscription.Key.Chase;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 0.2),
            ]);

            ModifyDamage amplifyDashDamage = new();

            amplifyDashDamage._attackTypes = new();
            amplifyDashDamage._attackTypes[MotionType.Dash] = true;

            amplifyDashDamage._damageTypes = new([true, true, true, true, true]);

            amplifyDashDamage._damagePercent = 1.3f;

            item.abilities = [
                amplifyDashDamage,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "WingedSpear";
            item.rarity = Rarity.Common;

            // EN: Winged Spear
            // KR: 날개달린 창
            // ZH: 黎明长枪
            item.itemName = "黎明长枪";

            // EN: Increases <color=#F25D1C>Physical Attack</color> by 15%.\n
            // Increases <color=#1787D8>Magic Attack</color> by 15%.\n
            // Increases Attack Speed by 15%.\n
            // Increases skill cooldown speed by 15%.\n
            // Increases swap cooldown speed by 15%.

            // KR: <color=#F25D1C>물리공격력</color>이 15% 증가합니다.\n
            // <color=#1787D8>마법공격력</color>이 15% 증가합니다.\n
            // 공격속도가 15% 증가합니다.\n
            // 스킬 쿨다운 속도가 15% 증가합니다.\n
            // 교대 쿨다운 속도가 15% 증가합니다.

            // ZH: <color=#F25D1C>物理攻击力</color>增加15%，\n
            // <color=#1787D8>魔法攻击力</color>增加15%，\n
            // 攻速增加15%，\n
            // 技能冷却速度增加15%，\n
            // 替换冷却速度增加15%。

            item.itemDescription = "<color=#F25D1C>物理攻击力</color>增加15%，\n"
                                 + "<color=#1787D8>魔法攻击力</color>增加15%，\n"
                                 + "攻速增加15%，\n"
                                 + "技能冷却速度增加15%，\n"
                                 + "替换冷却速度增加15%。";

            // EN: A golden spear ornamented with the wings of dawn.
            // KR: 여명의 날개로 치장된 금색 창
            // ZH: 黎明之翼为饰
            item.itemLore = "黎明之翼为饰";

            item.prefabKeyword1 = Inscription.Key.Duel;
            item.prefabKeyword2 = Inscription.Key.SunAndMoon;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 0.15),
                new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.15),
                new(Stat.Category.PercentPoint, Stat.Kind.BasicAttackSpeed, 0.15),
                new(Stat.Category.PercentPoint, Stat.Kind.SkillCooldownSpeed, 0.15),
                new(Stat.Category.PercentPoint, Stat.Kind.SwapCooldownSpeed, 0.15),
            ]);

            item.extraComponents = [
                typeof(WingedSpearEvolveBehavior),
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "WingedSpear_2";
            item.rarity = Rarity.Unique;

            item.obtainable = false;

            // EN: Solar-Winged Sword
            // KR: 햇빛 날개달린 검
            // ZH: 黎明长剑
            item.itemName = "黎明长剑";

            // EN: Increases <color=#F25D1C>Physical Attack</color> by 55%.\n
            // Increases Attack Speed by 25%.\n
            // Increases swap cooldown speed by 25%.

            // KR: <color=#F25D1C>물리공격력</color>이 55% 증가합니다.\n
            // 공격속도가 25% 증가합니다.\n
            // 교대 쿨다운 속도가 25% 증가합니다.

            // ZH: <color=#F25D1C>物理攻击力</color>增加55%，\n
            // 攻速增加25%，\n
            // 替换冷却速度增加25%。

            item.itemDescription = "<color=#F25D1C>物理攻击力</color>增加55%，\n"
                                 + "攻速增加25%，\n"
                                 + "替换冷却速度增加25%。";

            // EN: A golden sword ornamented with the wings of dawn.
            // KR: 여명의 날개로 치장된 금색 검
            // ZH: 黎明之光为刃
            item.itemLore = "黎明之光为刃";

            item.prefabKeyword1 = Inscription.Key.Duel;
            item.prefabKeyword2 = Inscription.Key.Arms;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 0.55),
                new(Stat.Category.PercentPoint, Stat.Kind.BasicAttackSpeed, 0.25),
                new(Stat.Category.PercentPoint, Stat.Kind.SwapCooldownSpeed, 0.25),
            ]);

            item.forbiddenDrops = new[]
            {
                "SwordOfSun",
                "RingOfMoon",
                "ShardOfDarkness",
                "Custom-WingedSpear"
            };

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "WingedSpear_3";
            item.rarity = Rarity.Unique;

            item.obtainable = false;

            // EN: Lunar-Winged Insignia
            // KR: 달빛 날개달린 휘장
            // ZH: 黎明徽章
            item.itemName = "黎明徽章";

            // EN: Increases <color=#1787D8>Magic Attack</color> by 55%.\n
            // Increases skill cooldown speed by 25%.\n
            // Increases swap cooldown speed by 25%.

            // KR: <color=#1787D8>마법공격력</color>이 55% 증가합니다.\n
            // 스킬 쿨다운 속도가 25% 증가합니다.\n
            // 교대 쿨다운 속도가 25% 증가합니다.

            // ZH: <color=#1787D8>魔法攻击力</color>增加55%，\n
            // 技能冷却速度增加25%，\n
            // 替换冷却速度增加25%。

            item.itemDescription = "<color=#1787D8>魔法攻击力</color>增加55%，\n"
                                 + "技能冷却速度增加25%，\n"
                                 + "替换冷却速度增加25%。";

            // EN: A golden insignia ornamented with the wings of dawn.
            // KR: 여명의 날개로 치장된 금색 휘장
            // ZH: 黎明之威为启
            item.itemLore = "黎明之威为启";

            item.prefabKeyword1 = Inscription.Key.Duel;
            item.prefabKeyword2 = Inscription.Key.Artifact;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.55),
                new(Stat.Category.PercentPoint, Stat.Kind.SkillCooldownSpeed, 0.25),
                new(Stat.Category.PercentPoint, Stat.Kind.SwapCooldownSpeed, 0.25),
            ]);

            item.forbiddenDrops = new[]
            {
                "SwordOfSun",
                "RingOfMoon",
                "ShardOfDarkness",
                "Custom-WingedSpear"
            };

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "WingedSpear_4";
            item.rarity = Rarity.Unique;

            item.obtainable = false;

            // EN: Wings of Dawn
            // KR: 여명의 날개
            // ZH: 黎明之翼
            item.itemName = "黎明之翼";

            // EN: Increases <color=#F25D1C>Physical Attack</color> by 75%.\n
            // Increases <color=#1787D8>Magic Attack</color> by 75%.\n
            // Increases Attack Speed by 45%.\n
            // Increases skill cooldown speed by 45%.\n
            // Increases swap cooldown speed by 45%.

            // KR: <color=#F25D1C>물리공격력</color>이 75% 증가합니다.\n
            // <color=#1787D8>마법공격력</color>이 75% 증가합니다.\n
            // 공격속도가 45% 증가합니다.\n
            // 스킬 쿨다운 속도가 45% 증가합니다.\n
            // 교대 쿨다운 속도가 45% 증가합니다.

            // ZH: <color=#F25D1C>物理攻击力</color>增加75%，\n
            // <color=#1787D8>魔法攻击力</color>增加75%，\n
            // 攻速增加45%，\n
            // 技能冷却速度增加45%，\n
            // 替换冷却速度增加45%。

            item.itemDescription = "<color=#F25D1C>物理攻击力</color>增加75%，\n"
                                 + "<color=#1787D8>魔法攻击力</color>增加75%，\n"
                                 + "攻速增加45%，\n"
                                 + "技能冷却速度增加45%，\n"
                                 + "替换冷却速度增加45%。";

            // EN: A divine spear donning the wings of dawn.
            // KR: 여명의 날개를 흡수한 신성한 창
            // ZH: 黎明神光伴生
            item.itemLore = "黎明神光伴生";

            item.prefabKeyword1 = Inscription.Key.Duel;
            item.prefabKeyword2 = Inscription.Key.Duel;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 0.75),
                new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.75),
                new(Stat.Category.PercentPoint, Stat.Kind.BasicAttackSpeed, 0.45),
                new(Stat.Category.PercentPoint, Stat.Kind.SkillCooldownSpeed, 0.45),
                new(Stat.Category.PercentPoint, Stat.Kind.SwapCooldownSpeed, 0.45),
            ]);

            item.forbiddenDrops = new[]
            {
                "SwordOfSun",
                "RingOfMoon",
                "ShardOfDarkness",
                "Custom-WingedSpear"
            };

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "WingedSpear_5";
            item.rarity = Rarity.Unique;

            item.obtainable = false;

            // EN: Omen: Last Dawn
            // KR: 흉조: 최후의 여명
            // ZH: 预兆：黎明终末
            item.itemName = "预兆：黎明终末";

            // EN: Increases <color=#F25D1C>Physical Attack</color> by 110%.\n
            // Increases <color=#1787D8>Magic Attack</color> by 110%.\n
            // Increases Attack Speed by 65%.\n
            // Increases skill cooldown speed by 65%.\n
            // Increases swap cooldown speed by 65%.

            // KR: <color=#F25D1C>물리공격력</color>이 110% 증가합니다.\n
            // <color=#1787D8>마법공격력</color>이 110% 증가합니다.\n
            // 공격속도가 65% 증가합니다.\n
            // 스킬 쿨다운 속도가 65% 증가합니다.\n
            // 교대 쿨다운 속도가 65% 증가합니다.

            // ZH: <color=#F25D1C>物理攻击力</color>增加110%，\n
            // <color=#1787D8>魔法攻击力</color>增加110%，\n
            // 攻速增加65%，\n
            // 技能冷却速度增加65%，\n
            // 替换冷却速度增加65%。

            item.itemDescription = "<color=#F25D1C>物理攻击力</color>增加110%，\n"
                                 + "<color=#1787D8>魔法攻击力</color>增加110%，\n"
                                 + "攻速增加65%，\n"
                                 + "技能冷却速度增加65%，\n"
                                 + "替换冷却速度增加65%。";

            // EN: The sky cracks, darkness fills the world within.
            // KR: 하늘은 갈라져 속세를 어둠에 물들지니.
            // ZH: 黎明去，永夜至。
            item.itemLore = "黎明去，永夜至。";

            item.prefabKeyword1 = Inscription.Key.Omen;
            item.prefabKeyword2 = Inscription.Key.Duel;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 1.1),
                new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 1.1),
                new(Stat.Category.PercentPoint, Stat.Kind.BasicAttackSpeed, 0.65),
                new(Stat.Category.PercentPoint, Stat.Kind.SkillCooldownSpeed, 0.65),
                new(Stat.Category.PercentPoint, Stat.Kind.SwapCooldownSpeed, 0.65),
            ]);

            item.forbiddenDrops = new[]
            {
                "SwordOfSun",
                "RingOfMoon",
                "ShardOfDarkness",
                "Custom-WingedSpear"
            };

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "Fonias";
            item.rarity = Rarity.Unique;

            // EN: Fonias
            // KR: 포니아스
            // ZH: 魔王镰刀
            item.itemName = "魔王镰刀";

            // EN: Increases Crit Chance by 5%.\n
            // Increases Crit Damage by 25%.\n
            // Amplifies damage dealt to enemies by 10%.\n
            // Amplfies damage dealt to an adventurer or a boss by 5%.

            // KR: 치명타 확률이 5% 증가합니다.\n
            // 치평타 피해가 25% 증가합니다.\n
            // 적에게 입히는 데미지가 10% 증폭됩니다.\n
            // 모험가 혹은 보스에게 입히는 데미지가 5% 증폭됩니다.

            // ZH: 暴击率增加5%，\n
            // 暴击伤害增加25%，\n
            // 对敌人造成伤害增幅10%，\n
            // 对冒险者与BOSS伤害再增幅5%。

            item.itemDescription = "暴击率增加5%，\n"
                                 + "暴击伤害增加25%，\n"
                                 + "对敌人造成伤害增幅10%，\n"
                                 + "对冒险者与BOSS伤害再增幅5%。";

            // EN: An ancient scythe imbued with cursed power.\nIt was once wielded by a former demon king.
            // KR: 전대 마왕중 한명이 사용했다는 저주의 기운을 뿜어내는 고대의 낫
            // ZH: 充满诅咒力量的古镰刀，是前代魔王的武器。
            item.itemLore = "充满诅咒力量的古镰刀，是前代魔王的武器。";

            item.prefabKeyword1 = Inscription.Key.Execution;
            item.prefabKeyword2 = Inscription.Key.Strike;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.CriticalChance, 0.05),
                new(Stat.Category.PercentPoint, Stat.Kind.CriticalDamage, 0.25),
            ]);

            ModifyDamage amplifyDamage = new();

            amplifyDamage._attackTypes = new([true, true, true, true, true, true, true, true, true]);

            amplifyDamage._damageTypes = new([true, true, true, true, true]);

            amplifyDamage._damagePercent = 1.1f;

            item.abilities = [
                new FoniasAbility(),
                amplifyDamage,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "SpikyRapida";
            item.rarity = Rarity.Rare;

            // EN: Spiky Rapida
            // KR: 가시덤불 레이피어
            // ZH: 刺头扎花
            item.itemName = "刺头扎花";

            // EN: Increases Attack Speed by 20%.\n
            // Every 3rd normal attack, inflicts Wound to enemies that were hit.

            // KR: 공격속도가 20% 증가합니다.\n
            // 3회 째 기본공격마다 피격된 적에게 상처를 입힙니다.

            // ZH: 攻速增加20%，\n
            // 第三次普攻命中敌人时给予一层创伤。

            item.itemDescription = "攻速增加20%，\n"
                                 + "第三次普攻命中敌人时给予一层创伤。";

            // EN: In ancient times, when there was no English language yet, you would have been called "Victor".....
            // KR: 태초의 시절, 이곳의 언어도 없던 때에 당신은 "빅토르" 라고 불렸던 것 같다.....
            // ZH: 古时还不存在英语的时候，你应该被称为“征服者”.....
            item.itemLore = "古时还不存在英语的时候，你应该被称为“征服者”.....";

            item.prefabKeyword1 = Inscription.Key.ExcessiveBleeding;
            item.prefabKeyword2 = Inscription.Key.Rapidity;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.BasicAttackSpeed, 0.2),
            ]);

            item.abilities = [
                new SpikyRapidaAbility(),
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "WeirdHerbs";
            item.rarity = Rarity.Rare;

            // EN: Weird Herbs
            // KR: 수상한 허브
            // ZH: 怪异草药
            item.itemName = "怪异草药";

            // EN: Swapping increases skill cooldown speed by 25% and Crit Rate by 12% for 6 seconds.

            // KR: 교대 시 6초 동안 스킬 쿨다운 속도가 25% 증가하고 치명타 확률이 12% 증가합니다.

            // ZH: 替换时增加25%技能冷却速度与12%暴击率，持续6秒。

            item.itemDescription = "替换时增加25%技能冷却速度与12%暴击率，持续6秒。";

            // EN: Quartz-infused herbs which you can find all over the dark forest.
            // KR: 어둠의 숲 전역에서 찾을 수 있는 마석과 융합된 허브
            // ZH: 一种存在于黑暗森林中的被注入石英的草药。
            item.itemLore = "一种存在于黑暗森林中的被注入石英的草药。";

            item.prefabKeyword1 = Inscription.Key.Mutation;
            item.prefabKeyword2 = Inscription.Key.Misfortune;

            WeirdHerbsAbility ability = new()
            {
                _timeout = 6.0f,
                _stat = new Stat.Values(
                [
                    new(Stat.Category.PercentPoint, Stat.Kind.SkillCooldownSpeed, 0.25),
                    new(Stat.Category.PercentPoint, Stat.Kind.CriticalChance, 0.12),
                ]),
            };

            item.abilities = [
                ability,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "AccursedSabre";
            item.rarity = Rarity.Unique;

            item.gearTag = Gear.Tag.Omen;
            item.obtainable = false;

            // EN: Omen: Accursed Sabre
            // KR: 저주받은 단도
            // ZH: 预兆：诅咒佩刀
            item.itemName = "预兆：诅咒佩刀";

            // EN: Basic attacks and skills have a 10% chance to apply Wound.\n
            // Every 2nd Bleed inflicts Bleed twice.

            // KR: 적 공격 시 10% 확률로 상처를 부여합니다.\n
            // 2회 째 출혈마다 출혈을 한번 더 부여합니다.

            // ZH: 普通攻击与技能伤害有10%概率创伤，\n
            // 每第二次流血触发2次流血。

            item.itemDescription = "普通攻击与技能伤害有10%概率创伤，\n"
                                 + "每第二次流血触发2次流血。";

            // EN: Sabre of the great duelist Sly who left his final memento in the form of never-ending anarchy and bloodshed.
            // KR: 끝없는 반역과 학살을 낳았던 세계 제일의 결투가 슬라이의 단도
            // ZH: 伟大决斗家斯莱（哪来的骨钉大师）的佩刀，他留以后世的是无休止的流血与混乱（确实）。
            item.itemLore = "伟大决斗家斯莱（哪来的骨钉大师）的佩刀，他留以后世的是无休止的流血与混乱（确实）。";

            item.prefabKeyword1 = Inscription.Key.Omen;
            item.prefabKeyword2 = Inscription.Key.ExcessiveBleeding;

            var applyStatus = new ApplyStatusOnGaveDamage();
            var status = Kind.Wound;
            applyStatus._cooldownTime = 0.1f;
            applyStatus._chance = 10;
            applyStatus._attackTypes = new();
            applyStatus._attackTypes[MotionType.Basic] = true;
            applyStatus._attackTypes[MotionType.Skill] = true;

            applyStatus._types = new();
            applyStatus._types[AttackType.Melee] = true;
            applyStatus._types[AttackType.Ranged] = true;
            applyStatus._types[AttackType.Projectile] = true;

            applyStatus._status = new ApplyInfo(status);

            item.abilities = [
                new AccursedSabreAbility(),
                applyStatus,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "HeavyDutyCarleonHelmet";
            item.rarity = Rarity.Rare;

            item.gearTag = Gear.Tag.Carleon;

            // EN: Heavy-Duty Carleon Helmet
            // KR: 중보병용 칼레온 투구
            // ZH: 重型卡利恩头盔
            item.itemName = "重型卡利恩头盔";

            // EN: Increases <color=#F25D1C>Physical Attack</color> and <color=#1787D8>Magic Attack</color> by 30%.\n
            // For every Carleon item owned, increase Max HP by 15.

            // KR: <color=#F25D1C>물리공격력</color> 및 <color=#1787D8>마법공격력</color>이 30% 증가합니다.\n
            // 보유하고 있는 '칼레온' 아이템 1개당 최대 체력이 15 증가합니다.

            // ZH: <color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>增加30%，\n
            // 每持有一个卡利恩系列道具增加15血上限。

            item.itemDescription = "<color=#F25D1C>物理攻击力</color>与<color=#1787D8>魔法攻击力</color>增加30%，\n"
                                 + "每持有一个卡利恩系列道具增加15血上限。";

            // EN: Only the strongest of Carleon's front line soldiers can wear this.\nThat... isn't saying very much, but still.
            // KR: 가장 강한 칼레온의 최전선에 선 병사들만이 쓸 수 있는 투구.\n하지만 큰 의미는 없어보인다.
            // ZH: 我赐予你卡利恩最强大的前线士兵的头盔。呃，这不重要，快上前线去罢（恼）。
            item.itemLore = "我赐予你卡利恩最强大的前线士兵的头盔。呃，这不重要，快上前线去罢（恼）。";

            item.prefabKeyword1 = Inscription.Key.Antique;
            item.prefabKeyword2 = Inscription.Key.Spoils;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 0.3),
                new(Stat.Category.PercentPoint, Stat.Kind.MagicAttackDamage, 0.3),
            ]);

            StatBonusPerGearTag statBonusPerCarleonItem = new();

            statBonusPerCarleonItem._tag = Gear.Tag.Carleon;

            statBonusPerCarleonItem._statPerGearTag = new Stat.Values(new Stat.Value[] {
                new Stat.Value(Stat.Category.Constant, Stat.Kind.Health, 15),
            });

            item.abilities = [
                statBonusPerCarleonItem,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "CursedHourglass";
            item.rarity = Rarity.Legendary;

            // EN: Cursed Hourglass
            // KR: 저주받은 모래시계
            // ZH: 诅咒沙漏
            item.itemName = "诅咒沙漏";

            // EN: Upon entering a map or hitting a boss phase for the first time, amplifies damage dealt to enemies by 30% for 30 seconds.\n
            // When the effect is not active, increases damage received by 30%.

            // KR: 맵 입장 혹은 보스(페이즈 포함) 에게 처음 데미지를 줄 시 30초 동안 적에게 입히는 데미지가 30% 증폭됩니다.\n
            // 해당 효과가 발동 중이지 않을 때, 받는 데미지가 30% 증가합니다.

            // ZH: 每次进入地图或者第一次击中Boss后增幅30%造成的伤害，持续30秒。\n
            // 30秒后受到伤害增加30%。

            item.itemDescription = "每次进入地图或者第一次击中Boss后增幅30%造成的伤害，持续30秒。\n"
                                 + "30秒后受到伤害增加30%。";

            // EN: To carry such a burden voluntarily... You're either the bravest person I've ever met, or the most foolish.
            // KR: 이런 짐을 짊어지다니... 넌 아마 이 세상에서 가장 용감하거나 멍청한 사람이겠지.
            // ZH: 自愿承担这种风险，你是蠢呢，还是勇呢。
            item.itemLore = "自愿承担这种风险，你是蠢呢，还是勇呢。";

            item.prefabKeyword1 = Inscription.Key.ManaCycle;
            item.prefabKeyword2 = Inscription.Key.Execution;

            CursedHourglassAbility ability = new()
            {
                _timeout = 30,
                _inactiveStat = new Stat.Values(
                [
                    new(Stat.Category.Percent, Stat.Kind.TakingDamage, 1.3),
                ])
            };

            item.abilities = [
                ability,
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "LuckyCoin";
            item.rarity = Rarity.Common;

            // EN: Lucky Coin
            // KR: 행운의 동전
            // ZH: 幸运币
            item.itemName = "幸运币";

            // EN: Increases Crit Rate by 5%.\n
            // Increases Gold gain by 10%.

            // KR: 치명타 확률이 5% 증가합니다.\n
            // 금화 획득량이 10% 증가합니다.

            // ZH: 增加5%暴击率，\n
            // 增加10%金币获取。

            item.itemDescription = "增加5%暴击率，\n"
                                 + "增加10%金币获取。";

            // EN: Oh, must be my lucky day!
            // KR: 오늘은 운수가 좋은 날인가 보군!
            // ZH: 嚯，咱今天可算来着了！
            item.itemLore = "嚯，咱今天可算来着了！";

            item.prefabKeyword1 = Inscription.Key.Treasure;
            item.prefabKeyword2 = Inscription.Key.Misfortune;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.CriticalChance, 0.05),
            ]);

            item.abilities = [
                new LuckyCoinAbility(),
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "TaintedRedScarf";
            item.rarity = Rarity.Rare;

            // EN: Tainted Red Scarf
            // KR: 변색된 붉은 목도리
            // ZH: 藏污红围巾
            item.itemName = "藏污红围巾";

            // EN: Increases dash cooldown speed by 20%.\n
            // Decreases dash distance by 30%.

            // KR: 대쉬 쿨다운 속도가 20% 증가합니다.\n
            // 대쉬 거리가 30% 감소합니다.

            // ZH: 疾驰冷却速度增加20%，\n
            // 减少30%疾驰距离。

            item.itemDescription = "疾驰冷却速度增加20%，\n"
                                 + "减少30%疾驰距离。";

            // EN: A small scarf that was once part of an old doll
            // KR: 어떤 인형에서 떨어져 나온 작은 목도리
            // ZH: 曾经被戴在一个小破娃娃身上的红色围巾。
            item.itemLore = "曾经被戴在一个小破娃娃身上的红色围巾。";

            item.prefabKeyword1 = Inscription.Key.Mystery;
            item.prefabKeyword2 = Inscription.Key.Chase;

            item.stats = new Stat.Values(
            [
                new(Stat.Category.PercentPoint, Stat.Kind.DashCooldownSpeed, 0.2),
                new(Stat.Category.Percent, Stat.Kind.DashDistance, 0.7),
            ]);

            item.extraComponents = [
                typeof(TaintedRedScarfEvolveBehavior),
            ];

            items.Add(item);
        }
        {
            var item = new CustomItemReference();
            item.name = "TatteredPlushie";
            item.rarity = Rarity.Legendary;

            item.obtainable = false;

            // EN: Tattered Plushie
            // KR: 해진 인형
            // ZH: 最 好 的 朋 友（迫 真）
            item.itemName = "最 好 的 朋 友（迫 真）";

            // EN: Every 5 seconds, depletes 10% of your Max HP and permanently grants you 5% amplification on damage dealt to enemies.\n
            // Upon killing an enemy, recovers 2% of your Max HP.

            // KR: 5초마다 최대 체력의 10%에 달하는 피해를 입고 영구적으로 적들에게 입히는 데미지가 5% 증폭됩니다.\n
            // 적을 처치할 때마다 최대 체력의 2%를 회복합니다.

            // ZH: 每5秒消耗10%最大生命值的血量，每消耗一次血量增幅5%伤害，\n
            // 杀死敌人回复2%血量。

            item.itemDescription = "每5秒消耗10%最大生命值的血量，每消耗一次血量增幅5%伤害，\n"
                                 + "杀死敌人回复2%血量。";

            // EN: bEsT FrIenDs fOrEveR
            // KR: 영원히 함께 영원히 함께 영원히 함께 영원히 함께 영원히 함께 영원히 함께 영원히 함께 영원히 함께 영원히 함께 영원히 함께 영원히 함께
            // ZH: 永怨的朋友
            item.itemLore = "永怨的朋友";

            item.prefabKeyword1 = Inscription.Key.Mystery;
            item.prefabKeyword2 = Inscription.Key.Sin;

            TatteredPlushieAbility ability = new()
            {
                _timeout = 5.0f,
            };

            item.abilities = [
                ability,
            ];

            items.Add(item);
        }

        return items;
    }

    internal static void LoadSprites()
    {
        Items.ForEach(item => item.LoadSprites());
    }

    internal static Dictionary<string, string> MakeStringDictionary()
    {
        Dictionary<string, string> strings = new(Items.Count * 8);

        foreach (var item in Items)
        {
            strings.Add("item/" + item.name + "/name", item.itemName);
            strings.Add("item/" + item.name + "/desc", item.itemDescription);
            strings.Add("item/" + item.name + "/flavor", item.itemLore);
        }

        return strings;
    }

    internal static List<Masterpiece.EnhancementMap> ListMasterpieces()
    {
        var masterpieces = Items.Where(i => (i.prefabKeyword1 == Inscription.Key.Masterpiece) || (i.prefabKeyword2 == Inscription.Key.Masterpiece))
                                .ToDictionary(i => i.name);

        return masterpieces.Where(item => masterpieces.ContainsKey(item.Key + "_2"))
                           .Select(item => new Masterpiece.EnhancementMap()
                           {
                               _from = new AssetReference(item.Value.guid),
                               _to = new AssetReference(masterpieces[item.Key + "_2"].guid),
                           })
                           .ToList();
    }
}
