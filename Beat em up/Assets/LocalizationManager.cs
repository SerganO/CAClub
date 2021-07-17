using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalizationManager
{
    public static event VoidFunc languageChanged;

    public static Sprite flagImage(string id)
    {
        return Resources.Load<Sprite>("Sprites/Flags/" + id);
    }

    public static Sprite currentImage
    {
        get
        {
            return flagImage(currentLanguageId);
        }
    }

    public static string currentLanguageId = "";
    static int currentLanguageIndex;

    public static void SetupLanguage(string id)
    {
        var language = languages.Find(x => x.languageCode == id);
        if (language != null)
        {

            currentLanguageId = id;
            currentLanguageIndex = languages.FindIndex(x => x.languageCode == id);

            local = language;
            PlayerPrefs.SetString("Language", id);
            languageChanged?.Invoke();
        }
    }

    public static void NextLanguage()
    {
        if (currentLanguageIndex == languages.Count - 1)
        {
            SetupLanguage(languages[0].languageCode);
        }
        else
        {
            SetupLanguage(languages[currentLanguageIndex + 1].languageCode);
        }


    }

    static List<LocalizateSet> languages = new List<LocalizateSet>()
    {
        new LocalizateSet()
    {
        languageCode = "ru",
        languageName = "Русский",

        AngelName = "Люцифер",
        RobotName = "D4-TO",
        ReaperName = "Сильван",
        MurName = "Ланселот",

        AngelDescription = "Универсальный герой. Обратите гнев богов против своих противников, будьте самим злом",
        RobotDescription = "Дальнобойный герой. Воспользуйтесь обширным встроенным арсеналом. Плазмомёты- это круто",
        ReaperDescription = "Герой-призыватель. Повелевайте мощью природы и призывайте на подмогу дружественные сущности",
        MurDescription = "Танк. Воспользуйтесь разрушительной силой против своих врагов, и не бойтесь за себя",

        Settings = "Настройки",
        Music = "Музыка",
        Sound = "Звуки",
        Language = "Язык",
        Back = "Назад",
        EnterName = "Введите имя...",
        Create = "Создать",
        Pause = "Пауза",
        Exit = "Выйти",

        AngelFireName = "Пылающий меч",
        AngelLightningName = "Божественный гнев",
        AngelVampireName = "Дар Аида",
        AngelAirName = "Амулет ветров",

        RobotAngleName = "Косой плазменный выстрел",
        RobotStraightName = "Прямой плазменный выстрел",
        RobotCloneName = "Голографическая копия",
        RobotMegaName = "Мега-пушка",
        RobotDodgeName = "Реактивные ускорители",

        ReaperKitName = "Гнев животных",
        ReaperDuhName = "Гнев духов",
        ReaperStunName = "Опутывание",
        ReaperBoomName = "Природный выплеск",

        MurBuffName = "Меч короля Артура",
        MurHealName = "Восстанавливающие зелье",
        MurInvulName = "Каменная кожа",
        MurBoomName = "Оглушающая смерть",
        MurDodgeName = "Разъярённый бык",

        AngelDodgeName = "Уворот",
        AngelSwordName = "Обычная атака",
        AngelHPName = "Здоровье",

        RobotMelleName = "Обычная атака",
        RobotHPName = "Здоровье",

        MurSwordName = "Обычная атака",
        MurHPName = "Здоровье",

        ReaperDodgeName = "Уворот",
        ReaperSwordName = "Обычная атака",
        ReaperHPName = "Здоровье",

        AngelFireDesc = "Уничтожьте врагов оружием, данным вам Богом",
        AngelLightningDesc = "Испепелите врагов яростью небес",
        AngelVampireDesc = "Восстановите себя, проливая кровь врагов",
        AngelAirDesc = "Мощный артефакт, позволяющий управлять потоками ветров",

        RobotAngleDesc = "Поразите выстрелом врага",
        RobotStraightDesc = "Поразите выстрелом врага, стоящего перед вами",
        RobotCloneDesc = "Установите свою голограмму, которая сможет отвлечь врагов",
        RobotMegaDesc = "Уничтожьте всех врагов, стоящих перед вами",
        RobotDodgeDesc = "Увернитесь от врага с помощью встроенных реактивных ускорителей",

        ReaperKitDesc = "Призовите себе на помощь кита, который будет сражаться на вашей стороне",
        ReaperDuhDesc = "Призовете духа, который будет сражаться на вашей стороне и восстанавливать вам здоровье",
        ReaperStunDesc = "Задержите врагов на некоторое время, опутав их корнями",
        ReaperBoomDesc = "Высвободите энергию внутри призванных вами китов, чтобы нанести урон всем противник поблизости",

        MurBuffDesc = "Усильте свои атаки с помощью реликвии",
        MurHealDesc = "Восстановите определённо количество ХП",
        MurInvulDesc = "Станьте неуязвимым на определенное время",
        MurBoomDesc = "Стукнете по земле с феноменальной силой, что нанесет урон в врагам вокруг",
        MurDodgeDesc = "Побегите на врагов, снеся все на своём пути",

        AngelDodgeDesc = "Увернитесь от удара врагов",
        AngelSwordDesc = "Нанесите урон врагу",
        AngelHPDesc = "Здоровье героя",

        ReaperDodgeDesc = "Увернитесь от удара врагов",
        ReaperSwordDesc = "Нанесите урон врагу",
        ReaperHPDesc = "Здоровье героя",

        MurSwordDesc = "Нанесите урон врагу",
        MurHPDesc = "Здоровье героя",

        RobotMelleDesc = "Нанесите урон врагу",
        RobotHPDesc = "Здоровье героя",

        max = "Максимальный уровень",

        hp = Helper.ColorText("red", "❤"),
        heal = Helper.ColorText("red", "❤+"),
        time = Helper.ColorText("yellow", "время действия"),
        count = Helper.ColorText("yellow", "количество"),
        buff = Helper.ColorText("green", "усиление"),
        damage = Helper.ColorText("red", "урон"),
        countdown = Helper.ColorText("orange", "⌛"),
        duration = Helper.ColorText("#ffa500ff", "длительность"),

        Continue = "Продолжить",
        Upgrade = "Улучшить",

        CreateProfile = "Создайте профиль",

        EndGameMessage = "Поздравляю!\nВы прошли игру. Можете дальше проходить миссии в своё удовольствие",
        DeleteConfirmation = "Вы уверены, что хотите удалить профиль: ",
        CreateError = "Ошибка создания профиля! Имя должно быть не менее 4-х символов, не содержать спец символов и быть уникальным",
        BuyAccept = "Вы уверены, что хотите купить героя: ",
        QuitAccept = "Вы уверены, что хотите выйти?",

        ////
        TopInfoPlanets1 = "Экран выбора планеты",
BottomInfoPlanets1 = "<color=orange><b>Иконка скрижали</b></color>\nОтображает количество собранных частей скрижали",
TopInfoPlanets2 = "Экран выбора планеты",
BottomInfoPlanets2 = "<color=orange><b>Кнопка планеты</b></color>\nНажмите, чтоб просмотреть доступные уровни на этой планете",
TopInfoPlanets3 = "Экран выбора планеты",
BottomInfoPlanets3 = "<color=orange><b>Кнопка улучшений</b></color>\nНажмите, чтоб перейти к экрану улучшений и покупки героев",
TopInfoPlanets4 = "Экран выбора планеты",
BottomInfoPlanets4 = "<color=orange><b>Кнопка настроек</b></color>\nНажмите, чтоб включить или выключить звук, музыку, а также поменять язык",

TopInfoPlanet1 = "Экран планеты",
BottomInfoPlanet1 = "<color=orange><b>Кнопка не пройденного уровня</b></color>\nКнопка желтого цвета отображает не пройденный уровень",
TopInfoPlanet2 = "Экран планеты",
BottomInfoPlanet2 = "<color=orange><b>Кнопка пройденного уровня</b></color>\nКнопка синего цвета отображает пройденный уровень",

TopInfoLevel1 = "Экран уровня",
BottomInfoLevel1 = "<color=orange><b>Здоровье героя</b></color>\nОтображает текущее здоровье героя",
TopInfoLevel2 = "Экран уровня",
BottomInfoLevel2 = "<color=orange><b>Здоровье противника</b></color>\nОтображает текущее здоровье противника",
TopInfoLevel3 = "Экран уровня",
BottomInfoLevel3 = "<color=orange><b>Кнопка основной атаки</b></color>\nНажмите, чтоб нанести урон противнику",
TopInfoLevel4 = "Экран уровня",
BottomInfoLevel4 = "<color=orange><b>Кнопка способности</b></color>\nНажмите, чтоб применить способность",
TopInfoLevel5 = "Экран уровня",
BottomInfoLevel5 = "<color=orange><b>Кнопка заблокированной способности</b></color>\nЗаблокированная способность, недоступна к использыванию",
TopInfoLevel6 = "Экран уровня",
BottomInfoLevel6 = "<color=orange><b>Кнопка меню</b></color>\nНажмите, чтоб попапасть в меню уровня",
TopInfoLevel7 = "Экран уровня",
BottomInfoLevel7 = "<color=orange><b>Область джойстика пермещения</b></color>\nЗажмите и перемещайте в зоне, чтоб управлять героем",

TopInfoHeroes1 = "Экран выбора героя",
BottomInfoHeroes1 = "<color=orange><b>Названия уровня</b></color>\nОтображает название выбраного уровня",
TopInfoHeroes2 = "Экран выбора героя",
BottomInfoHeroes2 = "<color=orange><b>Иконка сложности</b></color>\nОтображает сложность выбраного уровня. Чем больше жёлтых звёзд, тем сложнее уровень",
TopInfoHeroes3 = "Экран выбора героя",
BottomInfoHeroes3 = "<color=orange><b>Доступные персонажи</b></color>\nПозволяет выбрать одного из доступных героев",
TopInfoHeroes4 = "Экран выбора героя",
BottomInfoHeroes4 = "<color=orange><b>Имя героя</b></color>\nОтображает имя выбраного героя",
TopInfoHeroes5 = "Экран выбора героя",
BottomInfoHeroes5 = "<color=orange><b>Информация про героя</b></color>\nОтображает информацию про выбраного героя",
TopInfoHeroes6 = "Экран выбора героя",
BottomInfoHeroes6 = "<color=orange><b>Кнопка игры</b></color>\nНажмите, чтоб запустить уровень",

TopInfoMain1 = "Главный экран",
BottomInfoMain1 = "<color=orange><b>Кнопка запуска</b></color>\nНажмите чтобы начать игру",
TopInfoMain2 = "Главный экран",
BottomInfoMain2 = "<color=orange><b>Кнопка профиля</b></color>\nНажмите, чтоб перейти к экрану управления профилями",
TopInfoMain3 = "Главный экран",
BottomInfoMain3 = "<color=orange><b>Имя профиля</b></color>\nОтображает имя выбраного профиля",
TopInfoMain4 = "Главный экран",
BottomInfoMain4 = "<color=orange><b>Кнопка выхода</b></color>\nНажмите, чтоб выйти из игры",

TopInfoUpgrade1 = "Экран улучшения героев",
BottomInfoUpgrade1 = "<color=orange><b>Имя героя</b></color>\nОтображает имя выбраного героя",
TopInfoUpgrade2 = "Экран улучшения героев",
BottomInfoUpgrade2 = "<color=orange><b>Список героев</b></color>\nОтображает список приобретенных и неприобретенных героев",
TopInfoUpgrade3 = "Экран улучшения героев",
BottomInfoUpgrade3 = "<color=orange><b>Информация про героя</b></color>\nОтображает информацию про выбраного героя",
TopInfoUpgrade4 = "Экран улучшения героев",
BottomInfoUpgrade4 = "<color=orange><b>Кнопка покупки героя</b></color>\nНажмите, чтоб купить героя за опыт",
TopInfoUpgrade5 = "Экран улучшения героев",
BottomInfoUpgrade5 = "<color=orange><b>Название способности</b></color>\nОтображает название способности героя",
TopInfoUpgrade6 = "Экран улучшения героев",
BottomInfoUpgrade6 = "<color=orange><b>Иконка опыта</b></color>\nОтображает количество заработанного опыта",
TopInfoUpgrade7 = "Экран улучшения героев",
BottomInfoUpgrade7 = "<color=orange><b>Стоимость улучшения</b></color>\nОтображает стоимость улучшения или покупки способности героя",
TopInfoUpgrade8 = "Экран улучшения героев",
BottomInfoUpgrade8 = "<color=orange><b>Описание улучшения</b></color>\nОтображает информацию про способность и какое улучшение оно получит",
TopInfoUpgrade9 = "Экран улучшения героев",
BottomInfoUpgrade9 = "<color=orange><b>Детальное описание улучшения</b></color>\nЧтобы перейти нажмите на картинку способности\nОтображает детальную информацию про способность и какое улучшение оно получит",
TopInfoUpgrade10 = "Экран улучшения героев",
BottomInfoUpgrade10 = "<color=orange><b>Кнопка покупки улучшения</b></color>\nНажмите, чтоб купить улучшения способности",

TopInfoProfile1 = "Экран профилей",
BottomInfoProfile1 = "<color=orange><b>Кнопка создания</b></color>\nНажмите, чтоб создать профиль с именем, которое было введённое в текстовое поле",
TopInfoProfile2 = "Экран профилей",
BottomInfoProfile2 = "<color=orange><b>Профили</b></color>\nОтображает все созданные профили и позволяет выбрать один из них",
TopInfoProfile3 = "Экран профилей",
BottomInfoProfile3 = "<color=orange><b>Кнопка удаления</b></color>\nНажмите, чтоб удалить выбранный профиль",

TopInfoWin1 = "Экран победы",
BottomInfoWin1 = "<color=orange><b>Кнопка потверждения</b></color>\nНажмите, чтоб перейти к экрану выбора уровня планеты",
TopInfoWin2 = "Экран победы",
BottomInfoWin2 = "<color=orange><b>Иконка полученого опыта</b></color>\nОтображает количество полученого опыта",
TopInfoWin3 = "Экран победы",
BottomInfoWin3 = "<color=orange><b>Иконка полученой части скрижали</b></color>\nОтображает, что игрок обнаружил часть скрижали",

TopInfoLose1 = "Экран поражения",
BottomInfoLose1 = "<color=orange><b>Кнопка потверждения</b></color>\nНажмите, чтоб перейти к экрану выбора уровня планеты",

    },
        new LocalizateSet()
    {
        languageCode = "ua",
        languageName = "Українська",

        AngelName = "Люцифер",
        RobotName = "D4-TO",
        ReaperName = "Сільван",
        MurName = "Ланселот",

        AngelDescription = "Універсальний герой. Оберніть гнів богів проти своїх супротивників, будьте самим злом",
        RobotDescription = "Далекобійний герой. Скористайтеся великим вбудованим арсеналом. Плазмомети-це круто",
        ReaperDescription = "Герой-викликач. Користуйтесь міццю природи і викликайте на підмогу дружні сутності",
        MurDescription = "Танк. Скористайтеся руйнівною силою знищивши своїх ворогів, і не бійтеся за себе",

        Settings = "Налаштування",
        Music = "Музика",
        Sound = "Звуки",
        Language = "Мова",
        Back = "Назад",
        EnterName = "Введіть ім'я...",
        Create = "Створити",
        Pause = "Пауза",
        Exit = "Вийти",

        AngelFireName = "Палаючий меч",
        AngelLightningName = "Божественний гнів",
        AngelVampireName = "Дар Аїда",
        AngelAirName = "Амулет вітрів",

        RobotAngleName = "Косий плазмовий постріл",
        RobotStraightName = "Прямий плазмовий постріл",
        RobotCloneName = "Голографічна копія",
        RobotMegaName = "Мега-гармата",
        RobotDodgeName = "Реактивні прискорювачі",

        ReaperKitName = "Гнів тварин",
        ReaperDuhName = "Гнів духів",
        ReaperStunName = "Обплутування",
        ReaperBoomName = "Природний виплеск",

        MurBuffName = "Меч короля Артура",
        MurHealName = "Відновлююче зілля",
        MurInvulName = "Кам'яна шкіра",
        MurBoomName = "Приголомшуюча смерть",
        MurDodgeName = "Розлючений бик",

        AngelDodgeName = "Уворот",
        AngelSwordName = "Звичайна атака",
        AngelHPName = "Здоров'я",

        RobotMelleName = "Звичайна атака",
        RobotHPName = "Здоров'я",

        MurSwordName = "Звичайна атака",
        MurHPName = "Здоров'я",

        ReaperDodgeName = "Уворот",
        ReaperSwordName = "Звичайна атака",
        ReaperHPName = "Здоров'я",

        AngelFireDesc = "Знищіть ворогів зброєю, наданою вам Богом",
        AngelLightningDesc = "Спопеліть ворогів люттю небес",
        AngelVampireDesc = "Зцілить себе, проливаючи кров ворогів",
        AngelAirDesc = "Потужний артефакт, що дозволяє управляти потоками вітрів",

        RobotAngleDesc = "Поцільте пострілом ворога",
        RobotStraightDesc = "Поцільте пострілом ворога, що стоїть перед вами",
        RobotCloneDesc = "Встановіть свою голограму, яка зможе відвернути ворогів",
        RobotMegaDesc = "Знищте всіх ворогів, що стоять перед вами",
        RobotDodgeDesc = "Ухиляйтеся від ворога за допомогою вбудованих реактивних прискорювачів",

        ReaperKitDesc = "Покличте собі на допомогу кита, який буде битися на вашому боці",
        ReaperDuhDesc = "Покличте духа, який буде битися на вашому боці і відновлювати вам здоров'я",
        ReaperStunDesc = "Затримайте ворогів на деякий час, обплутавши їх корінням",
        ReaperBoomDesc = "Вивільніть енергію всередині покликаних вами китів, щоб завдати шкоди всім противникам поблизу",

        MurBuffDesc = "Підсильте свої атаки за допомогою реліквії",
        MurHealDesc = "Відновіть певну кількість ХП",
        MurInvulDesc = "Станьте невразливим на певний час",
        MurBoomDesc = "Гупніть по землі з феноменальною силою, що завдасть шкоди ворогам навколо",
        MurDodgeDesc = "Побіжіть на ворогів, знісши все на своєму шляху",

        AngelDodgeDesc = "Ухиліться від ударів ворогів",
        AngelSwordDesc = "Нанесіть шкоди ворогу",
        AngelHPDesc = "Здоров'я героя",

        ReaperDodgeDesc = "Ухиліться від ударів ворогів",
        ReaperSwordDesc = "Нанесіть шкоди ворогу",
        ReaperHPDesc = "Здоров'я героя",

        MurSwordDesc = "Нанесіть шкоди ворогу",
        MurHPDesc = "Здоров'я героя",

        RobotMelleDesc = "Нанесіть шкоди ворогу",
        RobotHPDesc = "Здоров'я героя",

        max = "Максимальний рівень",

        hp = Helper.ColorText("red", "❤"),
        heal = Helper.ColorText("red", "❤+"),
        time = Helper.ColorText("yellow", "час дії"),
        count = Helper.ColorText("yellow", "кількість"),
        buff = Helper.ColorText("green", "посилення"),
        damage = Helper.ColorText("red", "шкода"),
        countdown = Helper.ColorText("orange", "⌛"),
        duration = Helper.ColorText("#ffa500ff", "тривалість"),

        Continue = "Продовжити",
        Upgrade = "Вдосконалити",

        CreateProfile = "Створіть профіль",
        //////
EndGameMessage = "Вітаю!\nВи пройшли гру. Можете далі проходити місії в своє задоволення.",
DeleteConfirmation = "Ви впевнені, що хочете видалити профіль:",
CreateError = "Помилка створення профілю! Ім'я повинно бути не менше 4-х і не більше 12-и символів, не містити спецсимволів і бути унікальним",

        BuyAccept = "Ви впевнені, що хочете придбати героя: ",
        QuitAccept = "Ви впевнені, що хочете вийти?",

        ////
TopInfoPlanets1 = "Екран вибору планети",
BottomInfoPlanets1 = "<color=orange><b>Іконка скрижалі</b></color>\nВідображає кількість зібраних частин скрижалі",
TopInfoPlanets2 = "Екран вибору планети",
BottomInfoPlanets2 = "<color=orange><b>Кнопка планети</b></color>\nНатисніть, щоб переглянути доступні рівні на цій планеті",
TopInfoPlanets3 = "Екран вибору планети",
BottomInfoPlanets3 = "<color=orange><b>Кнопка поліпшень</b></color>\nНатисніть, щоб перейти до екрану поліпшень і купівлі героїв",
TopInfoPlanets4 = "Екран вибору планети",
BottomInfoPlanets4 = "<color=orange><b>Кнопка налаштувань</b></color>\nНатисніть, щоб включити або вимкнути звук, музику, а також змінити мову",

TopInfoPlanet1 = "Екран планети",
BottomInfoPlanet1 = "<color=orange><b>Кнопка не пройденого рівня</b></color>\nКнопка жовтого кольору відображає не пройдений рівень",
TopInfoPlanet2 = "Екран планети",
BottomInfoPlanet2 = "<color=orange><b>Кнопка пройденого рівня</b></color>\nКнопка синього кольору відображає пройдений рівень",

TopInfoLevel1 = "Екран рівня",
BottomInfoLevel1 = "<color=orange><b>Здоров'я героя</b></color>\nВідображає поточне здоров'я героя",
TopInfoLevel2 = "Екран рівня",
BottomInfoLevel2 = "<color=orange><b>Здоров'я противника</b></color>\nВідображає поточне здоров'я противника",
TopInfoLevel3 = "Екран рівня",
BottomInfoLevel3 = "<color=orange><b>Кнопка основної атаки</b></color>\nНатисніть, щоб завдати шкоди противнику",
TopInfoLevel4 = "Екран рівня",
BottomInfoLevel4 = "<color=orange><b>Кнопка здібності</b></color>\nНатисніть, щоб застосувати здатність",
TopInfoLevel5 = "Екран рівня",
BottomInfoLevel5 = "<color=orange><b>Кнопка заблокованої здатності</b></color>\nЗаблокована здатність, недоступна до використання",
TopInfoLevel6 = "Екран рівня",
BottomInfoLevel6 = "<color=orange><b>Кнопка меню</b></color>\nНатисніть, щоб потрапити в меню рівня",
TopInfoLevel7 = "Екран рівня",
BottomInfoLevel7 = "<color=orange><b>Область джойстика переміщення</b></color>\nЗатисніть і переміщайте в зоні, щоб управляти героєм",

TopInfoHeroes1 = "Екран вибору героя",
BottomInfoHeroes1 = "<color=orange><b>Назва рівня</b></color>\nОтображает название выбраного уровня",
TopInfoHeroes2 = "Екран вибору героя",
BottomInfoHeroes2 = "<color=orange><b>Іконка складності</b></color>\nВідображає складність обраного рівня. Чим більше жовтих зірок, тим складніше рівень",
TopInfoHeroes3 = "Екран вибору героя",
BottomInfoHeroes3 = "<color=orange><b>Доступні персонажі</b></color>\nДозволяє вибрати одного з доступних героїв",
TopInfoHeroes4 = "Екран вибору героя",
BottomInfoHeroes4 = "<color=orange><b>Ім'я героя</b></color>\nВідображає ім'я обраного героя",
TopInfoHeroes5 = "Екран вибору героя",
BottomInfoHeroes5 = "<color=orange><b>Інформація про героя</b></color>\nВідображає інформацію про обраного героя",
TopInfoHeroes6 = "Екран вибору героя",
BottomInfoHeroes6 = "<color=orange><b>Кнопка гри</b></color>\nНатисніть, щоб запустити рівень",

TopInfoMain1 = "Головний екран",
BottomInfoMain1 = "<color=orange><b>Кнопка запуску</b></color>\nНатисніть, щоб почати гру",
TopInfoMain2 = "Головний екран",
BottomInfoMain2 = "<color=orange><b>Кнопка профілю</b></color>\nНатисніть, щоб перейти до екрану управління профілями",
TopInfoMain3 = "Головний екран",
BottomInfoMain3 = "<color=orange><b>Ім'я профілю</b></color>\nВідображає ім'я обраного профілю",
TopInfoMain4 = "Головний екран",
BottomInfoMain4 = "<color=orange><b>Кнопка виходу</b></color>\nНатисніть, щоб вийти з гри",

TopInfoUpgrade1 = "Екран поліпшення героїв",
BottomInfoUpgrade1 = "<color=orange><b>Ім'я героя</b></color>\nВідображає ім'я обраного героя",
TopInfoUpgrade2 = "Екран поліпшення героїв",
BottomInfoUpgrade2 = "<color=orange><b>Список героїв</b></color>\nВідображає список придбаних і не придбаних героїв",
TopInfoUpgrade3 = "Екран поліпшення героїв",
BottomInfoUpgrade3 = "<color=orange><b>Інформація про героя</b></color>\nВідображає інформацію про обраного героя",
TopInfoUpgrade4 = "Екран поліпшення героїв",
BottomInfoUpgrade4 = "<color=orange><b>Кнопка купівлі героя</b></color>\nНатисніть, щоб придбати героя за досвід",
TopInfoUpgrade5 = "Екран поліпшення героїв",
BottomInfoUpgrade5 = "<color=orange><b>Назва здатності</b></color>\nВідображає назву здатності героя",
TopInfoUpgrade6 = "Екран поліпшення героїв",
BottomInfoUpgrade6 = "<color=orange><b>Іконка досвіду</b></color>\nВідображає кількість заробленого досвіду",
TopInfoUpgrade7 = "Екран поліпшення героїв",
BottomInfoUpgrade7 = "<color=orange><b>Вартість поліпшення</b></color>\nВідображає вартість поліпшення або придбання здатності героя",
TopInfoUpgrade8 = "Екран поліпшення героїв",
BottomInfoUpgrade8 = "<color=orange><b>Опис поліпшення</b></color>\nВідображає інформацію про здатність і яке поліпшення воно отримає",
TopInfoUpgrade9 = "Екран поліпшення героїв",
BottomInfoUpgrade9 = "<color=orange><b>Детальний опис поліпшення</b></color>\nЩоб перейти натисніть на картинку здібності\nВідображає детальну інформацію про здатність і яке поліпшення воно отримає",
TopInfoUpgrade10 = "Екран поліпшення героїв",
BottomInfoUpgrade10 = "<color=orange><b>Кнопка купівлі поліпшення</b></color>\nНатисніть, щоб придбати поліпшення здатності",

TopInfoProfile1 = "Екран профілів",
BottomInfoProfile1 = "<color=orange><b>Кнопка створення</b></color>\nНатисніть, щоб створити профіль з ім'ям, яке було введене в текстове поле",
TopInfoProfile2 = "Екран профілів",
BottomInfoProfile2 = "<color=orange><b>Профілі</b></color>\nВідображає всі створені профілі і дозволяє вибрати один з них",
TopInfoProfile3 = "Екран профілів",
BottomInfoProfile3 = "<color=orange><b>Кнопка видалення</b></color>\nНатисніть, щоб видалити обраний профіль",

TopInfoWin1 = "Екран перемоги",
BottomInfoWin1 = "<color=orange><b>Кнопка підтвердження</b></color>\nНатисніть, щоб перейти до екрану вибору рівня планети",
TopInfoWin2 = "Екран перемоги",
BottomInfoWin2 = "<color=orange><b>Іконка отриманого досвіду</b></color>\nВідображає кількість отриманого досвіду",
TopInfoWin3 = "Екран перемоги",
BottomInfoWin3 = "<color=orange><b>Іконка отриманої частини скрижалі</b></color>\nВідображає, що гравець виявив частину скрижалі",

TopInfoLose1 = "Екран поразки",
BottomInfoLose1 = "<color=orange><b>Кнопка підтвердження</b></color>\nНатисніть, щоб перейти до екрану вибору рівня планети",
    },
        new LocalizateSet()
    {
        languageCode = "en",
        languageName = "English",

        AngelName = "Lucifer",
        RobotName = "D4-TO",
        ReaperName = "Sylvan",
        MurName = "Lancelot",

        AngelDescription = "Universal hero. Turn the wrath of the gods against your opponents, be evil yourself",
        RobotDescription = "Long-range hero. Take advantage of the extensive built-in arsenal. Plasma throwers are cool",
        ReaperDescription = "Summoner Hero. Command the power of nature and summon friendly entities to help",
        MurDescription = "Tank. Use destructive power against your enemies, and don't be afraid for yourself",

        Settings = "Settings",
        Music = "Music",
        Sound = "Sounds",
        Language = "Language",
        Back = "Back",
        EnterName = "Enter name ...",
        Create = "Create",
        Pause = "Pause",
        Exit = "Exit",

        AngelFireName = "Flaming Sword",
        AngelLightningName = "Divine Wrath",
        AngelVampireName = "Gift of Hades",
        AngelAirName = "Amulet of the Winds",

        RobotAngleName = "Diagon plasma shot",
        RobotStraightName = "Direct plasma shot",
        RobotCloneName = "Holographic copy",
        RobotMegaName = "Mega-Gun",
        RobotDodgeName = "Jet Boosters",

        ReaperKitName = "Animal Rage",
        ReaperDuhName = "Spirit Wrath",
        ReaperStunName = "Entanglement",
        ReaperBoomName = "Natural splash",

        MurBuffName = "Excalibur",
        MurHealName = "Regenerating Potion",
        MurInvulName = "Stoneskin",
        MurBoomName = "Deafening Death",
        MurDodgeName = "Angry Bull",

        AngelDodgeName = "Dodge",
        AngelSwordName = "Normal Attack",
        AngelHPName = "Health",

        RobotMelleName = "Normal Attack",
        RobotHPName = "Health",

        MurSwordName = "Normal Attack",
        MurHPName = "Health",

        ReaperDodgeName = "Dodge",
        ReaperSwordName = "Normal Attack",
        ReaperHPName = "Health",

        AngelFireDesc = "Destroy your enemies with the weapons God has given you",
        AngelLightningDesc = "Incinerate your enemies with the fury of the heavens",
        AngelVampireDesc = "Heal yourself by spilling the blood of your enemies",
        AngelAirDesc = "A powerful artifact that allows you to control the flow of winds",

        RobotAngleDesc = "Hit the enemy with a shot",
        RobotStraightDesc = "Hit the enemy in front of you with a shot",
        RobotCloneDesc = "Place your own hologram to distract enemies",
        RobotMegaDesc = "Destroy all enemies in front of you",
        RobotDodgeDesc = "Dodge the enemy with the built-in jet boosters",

        ReaperKitDesc = "Call upon a whale to fight by your side",
        ReaperDuhDesc = "Summon a spirit to fight by your side and restore your health",
        ReaperStunDesc = "Delay enemies for a while, entangling them with roots",
        ReaperBoomDesc = "Unleash the energy inside your summoned whales to damage all nearby foes",

        MurBuffDesc = "Boost your attacks with a relic",
        MurHealDesc = "Recover a certain amount of HP",
        MurInvulDesc = "Become invulnerable for a specified time",
        MurBoomDesc = "Hit the ground with phenomenal force, damaging enemies around you",
        MurDodgeDesc = "Run at enemies and destroy everything in your path",

        AngelDodgeDesc = "Dodge enemy strikes",
        AngelSwordDesc = "Damage the enemy",
        AngelHPDesc = "Hero Health",

        ReaperDodgeDesc = "Dodge enemy strikes",
        ReaperSwordDesc = "Damage the enemy",
        ReaperHPDesc = "Hero Health",

        MurSwordDesc = "Damage the enemy",
        MurHPDesc = "Hero Health",

        RobotMelleDesc = "Damage the enemy",
        RobotHPDesc = "Hero Health",

        max = "Maximum level",

        hp = Helper.ColorText("red", "❤"),
        heal = Helper.ColorText("red", "❤+"),
        time = Helper.ColorText("yellow", "time of action"),
        count = Helper.ColorText("yellow", "quantity"),
        buff = Helper.ColorText("green", "strengthening"),
        damage = Helper.ColorText("red", "damage"),
        countdown = Helper.ColorText("orange", "⌛"),
        duration = Helper.ColorText("#ffa500ff", "duration"),

        Continue = "Continue",
        Upgrade = "Upgrade",
        CreateProfile = "Create profile",
        ///
        TopInfoPlanets1 = "Planet selection screen",
BottomInfoPlanets1 = "<color=orange> <b> Tablet Icon </b> </color> \nDisplays the number of collected tablet pieces",
TopInfoPlanets2 = "Planet selection screen",
BottomInfoPlanets2 = "<color=orange> <b> Planet button </b> </color> \nClick to view the available levels on this planet",
TopInfoPlanets3 = "Planet Select Screen",
BottomInfoPlanets3 = "<color=orange> <b> Upgrade button </b> </color> \nClick to go to the hero upgrade and purchase screen",
TopInfoPlanets4 = "Planet selection screen",
BottomInfoPlanets4 = "<color=orange> <b> Settings button </b> </color> \nClick to turn sound, music on or off, and change language",

TopInfoPlanet1 = "Planet Screen",
BottomInfoPlanet1 = "<color=orange> <b> Button for not passed level </b> </color> \nButton in yellow color displays not passed level",
TopInfoPlanet2 = "Planet Screen",
BottomInfoPlanet2 = "<color=orange> <b> The passed level button </b> </color> \nThe blue button displays the passed level",

TopInfoLevel1 = "Level Screen",
BottomInfoLevel1 = "<color=orange> <b> Hero's health </b> </color> \nDisplays the current hero's health",
TopInfoLevel2 = "Level Screen",
BottomInfoLevel2 = "<color=orange> <b> Enemy health </b> </color> \nDisplays the current health of the enemy",
TopInfoLevel3 = "Level Screen",
BottomInfoLevel3 = "<color=orange> <b> Main attack button </b> </color> \nClick to damage the enemy",
TopInfoLevel4 = "Level Screen",
BottomInfoLevel4 = "<color=orange> <b> Ability button </b> </color> \nClick to use the ability",
TopInfoLevel5 = "Level Screen",
BottomInfoLevel5 = "<color=orange> <b> Blocked ability button </b> </color> \nBlocked ability, unavailable for use",
TopInfoLevel6 = "Level Screen",
BottomInfoLevel6 = "<color=orange> <b> Menu button </b> </color> \nClick to get to the level menu",
TopInfoLevel7 = "Level Screen",
BottomInfoLevel7 = "<color=orange> <b> Move joystick area </b> </color> \nClick and drag in the area to control the hero",

TopInfoHeroes1 = "Hero Select Screen",
BottomInfoHeroes1 = "<color=orange> <b> Level names </b> </color> \nDisplays the name of the selected level",
TopInfoHeroes2 = "Hero Select Screen",
BottomInfoHeroes2 = "<color=orange> <b> Difficulty icon </b> </color> \nDisplays the difficulty of the selected level. The more yellow stars, the more difficult the level",
TopInfoHeroes3 = "Hero Select Screen",
BottomInfoHeroes3 = "<color=orange> <b> Available characters </b> </color> \nAllows to select one of the available heroes",
TopInfoHeroes4 = "Hero Select Screen",
BottomInfoHeroes4 = "<color=orange> <b> Hero name </b> </color> \nDisplays the name of the selected hero",
TopInfoHeroes5 = "Hero Select Screen",
BottomInfoHeroes5 = "<color=orange> <b> Information about the hero </b> </color> \nDisplays information about the selected hero",
TopInfoHeroes6 = "Hero Select Screen",
BottomInfoHeroes6 = "<color=orange> <b> Game button </b> </color> \nClick to start level",

TopInfoMain1 = "Home Screen",
BottomInfoMain1 = "<color=orange> <b> Launch button </b> </color> \nClick to start the game",
TopInfoMain2 = "Home Screen",
BottomInfoMain2 = "<color=orange> <b> Profile button </b> </color> \nClick to go to the profile management screen",
TopInfoMain3 = "Home Screen",
BottomInfoMain3 = "<color=orange> <b> Profile name </b> </color> \nDisplays the name of the selected profile",
TopInfoMain4 = "Home Screen",
BottomInfoMain4 = "<color=orange> <b> Exit button </b> </color> \nClick to exit the game",

TopInfoUpgrade1 = "Hero Upgrade Screen",
BottomInfoUpgrade1 = "<color=orange> <b> Hero name </b> </color> \nDisplays the name of the selected hero",
TopInfoUpgrade2 = "Hero Upgrade Screen",
BottomInfoUpgrade2 = "<color=orange> <b> Heroes </b> </color> \nDisplays a list of purchased and unapplied heroes",
TopInfoUpgrade3 = "Hero Upgrade Screen",
BottomInfoUpgrade3 = "<color=orange> <b> Hero Information </b> </color> \nDisplays information about the selected hero",
TopInfoUpgrade4 = "Hero Upgrade Screen",
BottomInfoUpgrade4 = "<color=orange> <b> Hero buy button </b> </color> \nClick to buy a hero with experience",
TopInfoUpgrade5 = "Hero Upgrade Screen",
BottomInfoUpgrade5 = "<color=orange> <b> Ability name </b> </color> \nDisplays the name of the hero's ability",
TopInfoUpgrade6 = "Hero Upgrade Screen",
BottomInfoUpgrade6 = "<color=orange> <b> XP Icon </b> </color> \nDisplays the amount of XP earned",
TopInfoUpgrade7 = "Hero Upgrade Screen",
BottomInfoUpgrade7 = "<color=orange> <b> Upgrade cost </b> </color> \nDisplays the cost of upgrading or buying a hero's ability",
TopInfoUpgrade8 = "Hero Upgrade Screen",
BottomInfoUpgrade8 = "<color=orange> <b> Description of the upgrade </b> </color> \nDisplays information about the ability and what improvement it will receive",
TopInfoUpgrade9 = "Hero Upgrade Screen",
BottomInfoUpgrade9 = "<color=orange> <b> Detailed description of the improvement </b> </color> \nTo go click on the picture of the ability \nDisplays detailed information about the ability and what improvement it will receive",
TopInfoUpgrade10 = "Hero Upgrade Screen",
BottomInfoUpgrade10 = "<color=orange> <b> Buy upgrade button </b> </color> \nClick to buy ability upgrades",

TopInfoProfile1 = "Profiles Screen",
BottomInfoProfile1 = "<color=orange> <b> Create button </b> </color> \nClick to create a profile with the name that was entered in the text box",
TopInfoProfile2 = "Profiles Screen",
BottomInfoProfile2 = "<color=orange> <b> Profiles </b> </color> \nDisplays all created profiles and allows you to select one of them",
TopInfoProfile3 = "Profiles Screen",
BottomInfoProfile3 = "<color=orange> <b> Delete button </b> </color> \nClick to delete the selected profile",

TopInfoWin1 = "Victory Screen",
BottomInfoWin1 = "<color=orange> <b> Confirm button </b> </color> \nClick to go to the planet level selection screen",
TopInfoWin2 = "Victory Screen",
BottomInfoWin2 = "<color=orange> <b> Experience gained icon </b> </color> \nDisplays the amount of experience gained",
TopInfoWin3 = "Victory Screen",
BottomInfoWin3 = "<color=orange> <b> Icon of the received part of the tablet </b> </color> \nDisplays that the player has found a part of the tablet",

TopInfoLose1 = "Defeat Screen",
BottomInfoLose1 = "<color=orange> <b> Confirm button </b> </color> \nClick to go to the planet level selection screen",

EndGameMessage = "Congratulations!\nYou passed the game. You can continue to pass missions at your own pleasure",
DeleteConfirmation = "Are you sure you want to delete the profile:",
CreateError = "Error creating profile! Name must be at least 4 and no more than 12 characters, not contain special characters and be unique",
BuyAccept = "Are you sure you want to buy a hero: ",
QuitAccept = "Are you sure you want to quit?"

    }
};

    public static LocalizateSet local = null;



}


public class LocalizateSet
{
    bool isBinded = false;
    public string languageCode = "";
    public string languageName = "";

    public string AngelName = "";
    public string RobotName = "";
    public string ReaperName = "";
    public string MurName = "";

    public string AngelDescription = "";
    public string RobotDescription = "";
    public string ReaperDescription = "";
    public string MurDescription = "";

    public string Settings = "";
    public string Music = "";
    public string Sound = "";
    public string Language = "";
    public string Back = "";
    public string EnterName = "";
    public string Create = "";
    public string Pause = "";
    public string Exit = "";
    public string Continue = "";
    public string Upgrade = "";

    public string AngelFireName = "";
    public string AngelLightningName = "";
    public string AngelVampireName = "";
    public string AngelAirName = "";

    public string RobotAngleName = "";
    public string RobotStraightName = "";
    public string RobotCloneName = "";
    public string RobotMegaName = "";
    public string RobotDodgeName = "";

    public string ReaperKitName = "";
    public string ReaperDuhName = "";
    public string ReaperStunName = "";
    public string ReaperBoomName = "";

    public string MurBuffName = "";
    public string MurHealName = "";
    public string MurInvulName = "";
    public string MurBoomName = "";
    public string MurDodgeName = "";

    public string AngelDodgeName = "";
    public string AngelSwordName = "";
    public string AngelHPName = "";

    public string RobotMelleName = "";
    public string RobotHPName = "";

    public string MurSwordName = "";
    public string MurHPName = "";

    public string ReaperDodgeName = "";
    public string ReaperSwordName = "";
    public string ReaperHPName = "";


    public string AngelFireDesc = "";
    public string AngelLightningDesc = "";
    public string AngelVampireDesc = "";
    public string AngelAirDesc = "";

    public string RobotAngleDesc = "";
    public string RobotStraightDesc = "";
    public string RobotCloneDesc = "";
    public string RobotMegaDesc = "";
    public string RobotDodgeDesc = "";

    public string ReaperKitDesc = "";
    public string ReaperDuhDesc = "";
    public string ReaperStunDesc = "";
    public string ReaperBoomDesc = "";

    public string MurBuffDesc = "";
    public string MurHealDesc = "";
    public string MurInvulDesc = "";
    public string MurBoomDesc = "";
    public string MurDodgeDesc = "";

    public string AngelDodgeDesc = "";
    public string AngelSwordDesc = "";
    public string AngelHPDesc = "";

    public string ReaperDodgeDesc = "";
    public string ReaperSwordDesc = "";
    public string ReaperHPDesc = "";

    public string MurSwordDesc = "";
    public string MurHPDesc = "";

    public string RobotMelleDesc = "";
    public string RobotHPDesc = "";

    public string max = "";

    public string hp = "";
    public string heal = "";
    public string time = "";
    public string count = "";
    public string buff = "";
    public string damage = "";
    public string countdown = "";
    public string duration = "";

    public string EndGameMessage = "";
    public string DeleteConfirmation = "";
    public string CreateError = "";
    public string BuyAccept = "";
    public string QuitAccept = "";
    public string CreateProfile = "";

    public string TopInfoPlanets1 = "";
    public string BottomInfoPlanets1 = "";
    public string TopInfoPlanets2 = "";
    public string BottomInfoPlanets2 = "";
    public string TopInfoPlanets3 = "";
    public string BottomInfoPlanets3 = "";
    public string TopInfoPlanets4 = "";
    public string BottomInfoPlanets4 = "";

    public string TopInfoPlanet1 = "";
    public string BottomInfoPlanet1 = "";
    public string TopInfoPlanet2 = "";
    public string BottomInfoPlanet2 = "";

    public string TopInfoLevel1 = "";
    public string BottomInfoLevel1 = "";
    public string TopInfoLevel2 = "";
    public string BottomInfoLevel2 = "";
    public string TopInfoLevel3 = "";
    public string BottomInfoLevel3 = "";
    public string TopInfoLevel4 = "";
    public string BottomInfoLevel4 = "";
    public string TopInfoLevel5 = "";
    public string BottomInfoLevel5 = "";
    public string TopInfoLevel6 = "";
    public string BottomInfoLevel6 = "";
    public string TopInfoLevel7 = "";
    public string BottomInfoLevel7 = "";

    public string TopInfoHeroes1 = "";
    public string BottomInfoHeroes1 = "";
    public string TopInfoHeroes2 = "";
    public string BottomInfoHeroes2 = "";
    public string TopInfoHeroes3 = "";
    public string BottomInfoHeroes3 = "";
    public string TopInfoHeroes4 = "";
    public string BottomInfoHeroes4 = "";
    public string TopInfoHeroes5 = "";
    public string BottomInfoHeroes5 = "";
    public string TopInfoHeroes6 = "";
    public string BottomInfoHeroes6 = "";

    public string TopInfoMain1 = "";
    public string BottomInfoMain1 = "";
    public string TopInfoMain2 = "";
    public string BottomInfoMain2 = "";
    public string TopInfoMain3 = "";
    public string BottomInfoMain3 = "";
    public string TopInfoMain4 = "";
    public string BottomInfoMain4 = "";

    public string TopInfoUpgrade1 = "";
    public string BottomInfoUpgrade1 = "";
    public string TopInfoUpgrade2 = "";
    public string BottomInfoUpgrade2 = "";
    public string TopInfoUpgrade3 = "";
    public string BottomInfoUpgrade3 = "";
    public string TopInfoUpgrade4 = "";
    public string BottomInfoUpgrade4 = "";
    public string TopInfoUpgrade5 = "";
    public string BottomInfoUpgrade5 = "";
    public string TopInfoUpgrade6 = "";
    public string BottomInfoUpgrade6 = "";
    public string TopInfoUpgrade7 = "";
    public string BottomInfoUpgrade7 = "";
    public string TopInfoUpgrade8 = "";
    public string BottomInfoUpgrade8 = "";
    public string TopInfoUpgrade9 = "";
    public string BottomInfoUpgrade9 = "";
    public string TopInfoUpgrade10 = "";
    public string BottomInfoUpgrade10 = "";

    public string TopInfoProfile1 = "";
    public string BottomInfoProfile1 = "";
    public string TopInfoProfile2 = "";
    public string BottomInfoProfile2 = "";
    public string TopInfoProfile3 = "";
    public string BottomInfoProfile3 = "";

    public string TopInfoWin1 = "";
    public string BottomInfoWin1 = "";
    public string TopInfoWin2 = "";
    public string BottomInfoWin2 = "";
    public string TopInfoWin3 = "";
    public string BottomInfoWin3 = "";

    public string TopInfoLose1 = "";
    public string BottomInfoLose1 = "";


    public Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

    public void Bind()
    {
        keyValuePairs["languageName"] = languageName;

        keyValuePairs["AngelName"] = AngelName;
        keyValuePairs["RobotName"] = RobotName;
        keyValuePairs["ReaperName"] = ReaperName;
        keyValuePairs["MurName"] = MurName;

        keyValuePairs["AngelDescription"] = AngelDescription;
        keyValuePairs["RobotDescription"] = RobotDescription;
        keyValuePairs["ReaperDescription"] = ReaperDescription;
        keyValuePairs["MurDescription"] = MurDescription;

        keyValuePairs["Settings"] = Settings;
        keyValuePairs["Music"] = Music;
        keyValuePairs["Sound"] = Sound;
        keyValuePairs["Language"] = Language;
        keyValuePairs["Back"] = Back;
        keyValuePairs["EnterName"] = EnterName;
        keyValuePairs["Create"] = Create;
        keyValuePairs["Pause"] = Pause;
        keyValuePairs["Exit"] = Exit;

        keyValuePairs["AngelFireName"] = AngelFireName;
        keyValuePairs["AngelLightningName"] = AngelLightningName;
        keyValuePairs["AngelVampireName"] = AngelVampireName;
        keyValuePairs["AngelAirName"] = AngelAirName;

        keyValuePairs["RobotAngleName"] = RobotAngleName;
        keyValuePairs["RobotStraightName"] = RobotStraightName;
        keyValuePairs["RobotCloneName"] = RobotCloneName;
        keyValuePairs["RobotMegaName"] = RobotMegaName;
        keyValuePairs["RobotDodgeName"] = RobotDodgeName;

        keyValuePairs["ReaperKitName"] = ReaperKitName;
        keyValuePairs["ReaperDuhName"] = ReaperDuhName;
        keyValuePairs["ReaperStunName"] = ReaperStunName;
        keyValuePairs["ReaperBoomName"] = ReaperBoomName;

        keyValuePairs["MurBuffName"] = MurBuffName;
        keyValuePairs["MurHealName"] = MurHealName;
        keyValuePairs["MurInvulName"] = MurInvulName;
        keyValuePairs["MurBoomName"] = MurBoomName;
        keyValuePairs["MurDodgeName"] = MurDodgeName;

        keyValuePairs["AngelDodgeName"] = AngelDodgeName;
        keyValuePairs["AngelSwordName"] = AngelSwordName;
        keyValuePairs["AngelHPName"] = AngelHPName;

        keyValuePairs["RobotMelleName"] = RobotMelleName;
        keyValuePairs["RobotHPName"] = RobotHPName;

        keyValuePairs["MurSwordName"] = MurSwordName;
        keyValuePairs["MurHPName"] = MurHPName;

        keyValuePairs["ReaperDodgeName"] = ReaperDodgeName;
        keyValuePairs["ReaperSwordName"] = ReaperSwordName;
        keyValuePairs["ReaperHPName"] = ReaperHPName;


        keyValuePairs["AngelFireDesc"] = AngelFireDesc;
        keyValuePairs["AngelLightningDesc"] = AngelLightningDesc;
        keyValuePairs["AngelVampireDesc"] = AngelVampireDesc;
        keyValuePairs["AngelAirDesc"] = AngelAirDesc;

        keyValuePairs["RobotAngleDesc"] = RobotAngleDesc;
        keyValuePairs["RobotStraightDesc"] = RobotStraightDesc;
        keyValuePairs["RobotCloneDesc"] = RobotCloneDesc;
        keyValuePairs["RobotMegaDesc"] = RobotMegaDesc;
        keyValuePairs["RobotDodgeDesc"] = RobotDodgeDesc;

        keyValuePairs["ReaperKitDesc"] = ReaperKitDesc;
        keyValuePairs["ReaperDuhDesc"] = ReaperDuhDesc;
        keyValuePairs["ReaperStunDesc"] = ReaperStunDesc;
        keyValuePairs["ReaperBoomDesc"] = ReaperBoomDesc;

        keyValuePairs["MurBuffDesc"] = MurBuffDesc;
        keyValuePairs["MurHealDesc"] = MurHealDesc;
        keyValuePairs["MurInvulDesc"] = MurInvulDesc;
        keyValuePairs["MurBoomDesc"] = MurBoomDesc;
        keyValuePairs["MurDodgeDesc"] = MurDodgeDesc;

        keyValuePairs["AngelDodgeDesc"] = AngelDodgeDesc;
        keyValuePairs["AngelSwordDesc"] = AngelSwordDesc;
        keyValuePairs["AngelHPDesc"] = AngelHPDesc;

        keyValuePairs["ReaperDodgeDesc"] = ReaperDodgeDesc;
        keyValuePairs["ReaperSwordDesc"] = ReaperSwordDesc;
        keyValuePairs["ReaperHPDesc"] = ReaperHPDesc;

        keyValuePairs["MurSwordDesc"] = MurSwordDesc;
        keyValuePairs["MurHPDesc"] = MurHPDesc;

        keyValuePairs["RobotMelleDesc"] = RobotMelleDesc;
        keyValuePairs["RobotHPDesc"] = RobotHPDesc;

        keyValuePairs["hp"] = hp;
        keyValuePairs["heal"] = heal;
        keyValuePairs["time"] = time;
        keyValuePairs["count"] = count;
        keyValuePairs["buff"] = buff;
        keyValuePairs["damage"] = damage;
        keyValuePairs["countdown"] = countdown;
        keyValuePairs["duration"] = duration;

        keyValuePairs["Continue"] = Continue;
        keyValuePairs["Upgrade"] = Upgrade;


        keyValuePairs["EndGameMessage"] = EndGameMessage;
        keyValuePairs["DeleteConfirmation"] = DeleteConfirmation;
        keyValuePairs["CreateError"] = CreateError;
        keyValuePairs["BuyAccept"] = BuyAccept;
        keyValuePairs["QuitAccept"] = QuitAccept;
        keyValuePairs["CreateProfile"] = CreateProfile;


        keyValuePairs["TopInfoPlanets1"] = TopInfoPlanets1;
        keyValuePairs["BottomInfoPlanets1"] = BottomInfoPlanets1;
        keyValuePairs["TopInfoPlanets2"] = TopInfoPlanets2;
        keyValuePairs["BottomInfoPlanets2"] = BottomInfoPlanets2;
        keyValuePairs["TopInfoPlanets3"] = TopInfoPlanets3;
        keyValuePairs["BottomInfoPlanets3"] = BottomInfoPlanets3;
        keyValuePairs["TopInfoPlanets4"] = TopInfoPlanets4;
        keyValuePairs["BottomInfoPlanets4"] = BottomInfoPlanets4;

        keyValuePairs["TopInfoPlanet1"] = TopInfoPlanet1;
        keyValuePairs["BottomInfoPlanet1"] = BottomInfoPlanet1;
        keyValuePairs["TopInfoPlanet2"] = TopInfoPlanet2;
        keyValuePairs["BottomInfoPlanet2"] = BottomInfoPlanet2;

        keyValuePairs["TopInfoLevel1"] = TopInfoLevel1;
        keyValuePairs["BottomInfoLevel1"] = BottomInfoLevel1;
        keyValuePairs["TopInfoLevel2"] = TopInfoLevel2;
        keyValuePairs["BottomInfoLevel2"] = BottomInfoLevel2;
        keyValuePairs["TopInfoLevel3"] = TopInfoLevel3;
        keyValuePairs["BottomInfoLevel3"] = BottomInfoLevel3;
        keyValuePairs["TopInfoLevel4"] = TopInfoLevel4;
        keyValuePairs["BottomInfoLevel4"] = BottomInfoLevel4;
        keyValuePairs["TopInfoLevel5"] = TopInfoLevel5;
        keyValuePairs["BottomInfoLevel5"] = BottomInfoLevel5;
        keyValuePairs["TopInfoLevel6"] = TopInfoLevel6;
        keyValuePairs["BottomInfoLevel6"] = BottomInfoLevel6;
        keyValuePairs["TopInfoLevel7"] = TopInfoLevel7;
        keyValuePairs["BottomInfoLevel7"] = BottomInfoLevel7;

        keyValuePairs["TopInfoHeroes1"] = TopInfoHeroes1;
        keyValuePairs["BottomInfoHeroes1"] = BottomInfoHeroes1;
        keyValuePairs["TopInfoHeroes2"] = TopInfoHeroes2;
        keyValuePairs["BottomInfoHeroes2"] = BottomInfoHeroes2;
        keyValuePairs["TopInfoHeroes3"] = TopInfoHeroes3;
        keyValuePairs["BottomInfoHeroes3"] = BottomInfoHeroes3;
        keyValuePairs["TopInfoHeroes4"] = TopInfoHeroes4;
        keyValuePairs["BottomInfoHeroes4"] = BottomInfoHeroes4;
        keyValuePairs["TopInfoHeroes5"] = TopInfoHeroes5;
        keyValuePairs["BottomInfoHeroes5"] = BottomInfoHeroes5;
        keyValuePairs["TopInfoHeroes6"] = TopInfoHeroes6;
        keyValuePairs["BottomInfoHeroes6"] = BottomInfoHeroes6;

        keyValuePairs["TopInfoMain1"] = TopInfoMain1;
        keyValuePairs["BottomInfoMain1"] = BottomInfoMain1;
        keyValuePairs["TopInfoMain2"] = TopInfoMain2;
        keyValuePairs["BottomInfoMain2"] = BottomInfoMain2;
        keyValuePairs["TopInfoMain3"] = TopInfoMain3;
        keyValuePairs["BottomInfoMain3"] = BottomInfoMain3;
        keyValuePairs["TopInfoMain4"] = TopInfoMain4;
        keyValuePairs["BottomInfoMain4"] = BottomInfoMain4;

        keyValuePairs["TopInfoUpgrade1"] = TopInfoUpgrade1;
        keyValuePairs["BottomInfoUpgrade1"] = BottomInfoUpgrade1;
        keyValuePairs["TopInfoUpgrade2"] = TopInfoUpgrade2;
        keyValuePairs["BottomInfoUpgrade2"] = BottomInfoUpgrade2;
        keyValuePairs["TopInfoUpgrade3"] = TopInfoUpgrade3;
        keyValuePairs["BottomInfoUpgrade3"] = BottomInfoUpgrade3;
        keyValuePairs["TopInfoUpgrade4"] = TopInfoUpgrade4;
        keyValuePairs["BottomInfoUpgrade4"] = BottomInfoUpgrade4;
        keyValuePairs["TopInfoUpgrade5"] = TopInfoUpgrade5;
        keyValuePairs["BottomInfoUpgrade5"] = BottomInfoUpgrade5;
        keyValuePairs["TopInfoUpgrade6"] = TopInfoUpgrade6;
        keyValuePairs["BottomInfoUpgrade6"] = BottomInfoUpgrade6;
        keyValuePairs["TopInfoUpgrade7"] = TopInfoUpgrade7;
        keyValuePairs["BottomInfoUpgrade7"] = BottomInfoUpgrade7;
        keyValuePairs["TopInfoUpgrade8"] = TopInfoUpgrade8;
        keyValuePairs["BottomInfoUpgrade8"] = BottomInfoUpgrade8;
        keyValuePairs["TopInfoUpgrade9"] = TopInfoUpgrade9;
        keyValuePairs["BottomInfoUpgrade9"] = BottomInfoUpgrade9;
        keyValuePairs["TopInfoUpgrade10"] = TopInfoUpgrade10;
        keyValuePairs["BottomInfoUpgrade10"] = BottomInfoUpgrade10;

        keyValuePairs["TopInfoProfile1"] = TopInfoProfile1;
        keyValuePairs["BottomInfoProfile1"] = BottomInfoProfile1;
        keyValuePairs["TopInfoProfile2"] = TopInfoProfile2;
        keyValuePairs["BottomInfoProfile2"] = BottomInfoProfile2;
        keyValuePairs["TopInfoProfile3"] = TopInfoProfile3;
        keyValuePairs["BottomInfoProfile3"] = BottomInfoProfile3;

        keyValuePairs["TopInfoWin1"] = TopInfoWin1;
        keyValuePairs["BottomInfoWin1"] = BottomInfoWin1;
        keyValuePairs["TopInfoWin2"] = TopInfoWin2;
        keyValuePairs["BottomInfoWin2"] = BottomInfoWin2;
        keyValuePairs["TopInfoWin3"] = TopInfoWin3;
        keyValuePairs["BottomInfoWin3"] = BottomInfoWin3;

        keyValuePairs["TopInfoLose1"] = TopInfoLose1;
        keyValuePairs["BottomInfoLose1"] = BottomInfoLose1;

        isBinded = true;
    }

    public string GetValueForId(string id)
    {
        if (!isBinded) Bind();
        return keyValuePairs[id];
    }





}
