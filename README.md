
# Тестовое задание MiniRPG

**Файл конфигурации appsettings.json**

  Файл конфигурации содержит все применяемые в приложении настройки.
  

    {  
    "HeroBaseStats": { //Начальные параметры героя
      "MaxHealth": 100, //Максимальное здоровье
      "Health": 100, //Здоровье
      "Power": 1, //Мощность
      "Money": 2 //Монеты
    },
    "WinPossibility": { //Параметры формулы для расчета вероятности выигрыша Min(A% + Мощь * B%, C%)
      "A": 40,
      "B": 5,
      "C": 70
    },
    "AttackResult": { //Параметры, связанные с расчетами результатов атаки
      "Win": {
        "HealthLose": 10, //Количество здоровья, теряемого при выигрыше
        "MoneyReceive": 5, //Количество монет, получаемых при выигрыше
        "IsPercent": true //Флаг, определяющий тип HealthLose: true - значение указано в процентах, false - абсолютное значение
      },
      "Lose": { 
        "HealthLose": 40,
        "MoneyReceive": 0,
        "IsPercent": false
      }
    },
    "Weapon": {
      "Cost": 10, //стоимость оружия
      "MinPoints": 1, //минимальное количество очков добавляемого мощи
      "MaxPoints": 2 //максимальное количество очков  добавляемого мощи
    },
    "Armor": {
      "Cost": 10, //стоимость одежды
      "MinPoints": 1,//минимальное количество очков добавляемого максимального здоровья
      "MaxPoints": 2 //максимальное количество очков добавляемого максимального здоровья
    },
    "HealthRecover": {
      "Cost": 3, //стоимость лечения
      "MinPoints": 1, //минимальное количество очков восполнения здоровья
      "MaxPoints": 10 //максимальное количество очков восполнения здоровья
    }


