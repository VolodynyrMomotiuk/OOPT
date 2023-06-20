# Лабораторні роботи з дисципліни "Об'єктно-орієнтовані технології програмування"
Тема програмного забезпечення. Онлайн-освіта: Створення платформи для навчання та навчальних матеріалів, яка дозволяє студентам доступатися до курсів, виконувати завдання, спілкуватися з викладачами та отримувати зворотний зв'язок.
## Лабораторна робота 1
Написати програмне забезпечення, що описує застосування патерну
-	Фабричний метод.
> Опис задачі
>> Онлайн-платформа для навчання та навчальних матеріалів дозволяє студентам доступатися до різних курсів, виконувати завдання, спілкуватися з викладачами та отримувати зворотний зв'язок. Кожен курс має свої унікальні характеристики та повинен бути створений відповідно до свого типу.

> Опис реалізації
> - Створити абстрактний клас Course, який буде представляти загальні характеристики курсу.
> - Створити конкретні класи, які реалізують клас Course і представляють різні типи курсів (наприклад, MathCourse, ScienceCourse, тощо). Кожен клас повинен реалізувати метод Enroll, який виконує специфічні дії для запису на курс.
> - Створити абстрактний клас CourseFactory, який визначає метод CreateCourse, що повертає об'єкт типу Course. Цей клас буде використовуватися для створення конкретних курсів.
> - Створити конкретні класи, які реалізують клас CourseFactory і представляють різні типи фабричних методів (наприклад, MathCourseFactory, ScienceCourseFactory, тощо). Кожен клас повинен реалізувати метод CreateCourse, який створює об'єкт відповідного типу курсу.
> - Створити клас OnlineEducationPlatform, який приймає об'єкт типу CourseFactory у конструкторі. Цей клас буде використовувати фабричний метод для створення та запису на курс.
> - В основній функції Main створити об'єкти різних фабричних методів та платформи онлайн-освіти, передаючи в них відповідні фабрики. Викликати метод CreateAndEnrollCourse для кожної платформи, що спричинить створення та запис на відповідний курс.
## Лабораторна робота 2
Написати програмне забезпечення, що описує застосування породжуючий патерн 
-	Прототип (Prototype).
> Опис задачі
>> Використання патерну Прототип (Prototype) для створення і клонування курсів. Основна мета патерну Прототип полягає в тому, щоб дозволити створювати нові об'єкти шляхом клонування вже існуючих об'єктів, замість безпосереднього створення їх з нуля.

> У коді використовуються наступні класи:
> - CoursePrototype (абстрактний клас) є базовим класом для курсів-прототипів. Він визначає властивість Title для назви курсу і абстрактний метод Clone(), який повинен бути реалізований в похідних класах для клонування об'єктів.
> - ConcreteCourse (конкретний клас) є конкретною реалізацією CoursePrototype. Він наслідується від CoursePrototype і реалізовує метод Clone(), використовуючи MemberwiseClone(), щоб створити поверхневу копію об'єкта.
> - CourseManager (клас-керівник) використовує прототипи для створення нових курсів. Він має приватне поле _coursePrototype, яке зберігає початковий прототип курсу, переданий через конструктор. Метод CreateCourse() викликає метод Clone() на _coursePrototype, щоб отримати копію курсу.

## Лабораторна робота 3
Написати програмне забезпечення, що описує застосування породжуючий патерн 
-	Стратегія (Strategy).

Технічне завдання для даного коду полягає у створенні системи оцінювання відповідей на питання студентів з використанням патерна Стратегія (Strategy). 
> В основі реалізації лежать наступні компоненти:
>> Інтерфейс IGradingStrategy: Це інтерфейс, який визначає контракт для будь-якої стратегії оцінювання відповідей. У цьому інтерфейсі визначений один метод CalculateGrade, який приймає список об'єктів Answer і повертає оцінку (ціле число).
>> Конкретні реалізації стратегій оцінювання:
>> - SimpleGradingStrategy: Ця стратегія використовує простий алгоритм оцінювання. Вона перебирає кожну відповідь і підраховує кількість правильних відповідей. Результат обчислюється як відсоток правильних відповідей.
>> - WeightedGradingStrategy: Ця стратегія використовує алгоритм оцінювання з ваговими коефіцієнтами. Вона підраховує загальну вагу всіх відповідей і ваговий бал за правильну відповідь. Результат обчислюється як відсоток вагового балу від загальної ваги.

>> Клас Question: Цей клас представляє завдання і містить текст питання, список відповідей (Answer) і об'єкт стратегії оцінювання (GradingStrategy). Він також має метод CalculateGrade(), який викликає метод CalculateGrade об'єкта стратегії і передає йому список відповідей.
>> Клас Answer: Цей клас представляє відповідь студента на питання. Він має властивості Text (текст відповіді), IsCorrect (прапорець, що вказує, чи є відповідь правильною) і Weight (вага відповіді, що використовується у ваговому алгоритмі оцінювання).

> Цілью використання патерна Стратегія в даному випадку є розділення алгоритму оцінювання відповідей від самого класу питання. Це дозволяє динамічно вибирати стратегію оцінювання для кожного питання, залежно від його вимог і характеристик. Клас Question використовує об'єкт інтерфейсу IGradingStrategy для виконання обчислення оцінки, не залежно від конкретної реалізації стратегії. Такий підхід дозволяє з легкістю додавати нові стратегії оцінювання, без необхідності змінювати код класу Question. Крім того, це полегшує тестування окремих стратегій, оскільки вони можуть бути випробувані окремо від класу Question.

## Лабораторна робота 4
Написати програмне забезпечення, що описує застосування патерну
-	Макрокоманди.

Технічне завдання для коду полягає у створенні системи, яка дозволяє виконувати різні дії (команди) над об'єктами курсу, завдання та користувача. Для реалізації цієї системи використовується патерн Макрокоманди.
> Опис класів:
> - Клас "Course" (Курс): представляє курс і має властивість Name (назва курсу) та метод Enroll (зареєструватися на курс).
> - Клас "Assignment" (Завдання): представляє завдання і має властивість Name (назва завдання) та метод Submit (відправити завдання).
> - Клас "User" (Користувач): представляє користувача і має властивість Name (ім'я користувача) та метод SendMessage (відправити повідомлення користувачу).
> - Абстрактний клас "Command" (Команда): визначає базовий клас для всіх команд і має абстрактний метод Execute, який буде перевизначений у конкретних командах.
> - Конкретна команда "EnrollCourseCommand" (Команда реєстрації на курс): наслідується від класу Command і виконує дію зареєструватися на курс.
> - Конкретна команда "SubmitAssignmentCommand" (Команда відправки завдання): наслідується від класу Command і виконує дію відправки завдання.
> - Конкретна команда "SendMessageCommand" (Команда відправки повідомлення): наслідується від класу Command і виконує дію відправки повідомлення користувачу.
> - Клас "Invoker" (Викликач): містить список команд і має методи для додавання команд до черги (AddCommand) та виконання всіх команд (ExecuteCommands).

## Лабораторна робота 5
Написати програмне забезпечення, що описує застосування патерн 
-	Ітератор (Iterator). 

Реалізувати перегляд та перебір списку курсів на платформі з використанням патерну Ітератор.
> Опис функцій та їх призначення:
> - Клас Course містить властивості Title та Description, які описують курс.
> - Інтерфейс ICourseIterator має методи, які описують функціональність Ітератора, такі як отримання першого елемента, перехід до наступного елемента, перевірка закінчення перебору та отримання поточного елемента.
> - Клас CourseCollection містить колекцію курсів та реалізує IEnumerable<Course>, щоб його можна було перебирати за допомогою Ітератора. Він також надає метод AddCourse(), який додає курс до колекції.
> - Клас CourseIterator реалізує Ітератор і забезпечує функціональність перебору курсів. Він зберігає посилання на колекцію курсів та виконує методи Ітератора, такі як отримання першого елемента, перехід до наступного елемента, перевірка закінчення перебору та отримання поточного елемента.

## Лабораторна робота 6
Написати програмне забезпечення, що описує застосування патерн 
-	Інтерпретатор (Interpreter). 

Розробити імплементацію патерну Інтерпретатор (Interpreter) для виконання математичних операцій у контексті платформи для онлайн-освіти.
> Опис реалізації:
> - Інтерфейс IExpression визначає метод Interpret, який дозволяє інтерпретувати елемент мови.
> - Клас MathExpression реалізує інтерфейс IExpression та представляє вираз для виконання математичних операцій. У методі Interpret відбувається інтерпретація виразу та виконання математичної операції, результат зберігається в контексті.
> - Клас Context містить словник variables, який зберігає змінні та значення у контексті інтерпретації. Методи SetVariable та GetVariable використовуються для додавання та отримання значень з контексту.
> - Клас Interpreter містить список інтерпретаторів expressions та надає можливість додавати нові інтерпретатори методом AddExpression. Метод Interpret виконує інтерпретацію всіх доданих інтерпретаторів за допомогою методу Interpret інтерфейсу IExpression.
> - Клас OnlineEducationPlatform містить метод Main, який демонструє використання патерну Інтерпретатор у контексті платформи для онлайн-освіти. У цьому прикладі створюється контекст, створюється вираз mathExpression, створюється інтерпретатор interpreter та додається вираз. Після цього виконується інтерпретація, результат отримується з контексту і виводиться на екран.

## Лабораторна робота 7
Написати програмне забезпечення, що описує застосування породжуючий патерн 
-	Зберігач (Memento). 

Технічне завдання до цього коду полягає у збереженні та відновленні стану об'єкту Course за допомогою патерна Зберігач (Memento). Патерн Зберігач дозволяє зберігати та відновлювати попередні стани об'єктів без розкриття деталей їхньої реалізації.
> Основні компоненти коду:
> - Клас Course представляє курс і має властивості Title і Content, які визначають назву та зміст курсу відповідно.
> - Метод Save в класі Course створює об'єкт CourseMemento і повертає його. Цей об'єкт містить стан курсу, який потрібно зберегти.
> - Метод Restore в класі Course приймає об'єкт CourseMemento і відновлює стан курсу з цього об'єкта, присвоюючи значенням Title і Content значення з об'єкта CourseMemento.
> - Клас CourseMemento представляє об'єкт Memento, який зберігає стан курсу. Він має властивості Title і Content, які використовуються для збереження інформації про назву та зміст курсу.
> - Клас CourseCareTaker відповідає за збереження та відновлення стану курсу. Він має приватне поле _memento, яке зберігає об'єкт CourseMemento. Цей клас має властивість Memento, яка дозволяє отримати або встановити значення _memento.

## Лабораторна робота 8
Написати програмне забезпечення, що описує застосування патерн 
-	Декоратор (Decorator). 

Технічне завдання для коду полягає у створенні системи, яка надає можливість додавати додаткові функціональні можливості до базового курсу. Для досягнення цієї мети був використаний патерн Декоратор (Decorator).
> Основні компоненти системи включають:
> - Абстрактний клас Course: Цей клас є базовим класом для всіх курсів і містить абстрактний метод GetDescription(), який повертає опис курсу.
> - Конкретний клас BasicCourse: Цей клас представляє конкретний курс і реалізує метод GetDescription(), щоб повернути опис базового курсу.
> - Абстрактний клас CourseDecorator: Цей клас є базовим класом для всіх декораторів курсу. Він містить посилання на об'єкт типу Course і реалізує метод GetDescription(), який делегує виклик методу GetDescription() до посилання на об'єкт Course.
> - Конкретні класи декораторів (MaterialsDecorator, AssignmentsDecorator, CommunicationDecorator): Кожен з цих класів розширює функціональність базового курсу, додаючи додаткові можливості. Кожен декоратор отримує посилання на об'єкт типу Course через конструктор і реалізує метод GetDescription(), додаючи свою функціональність до опису базового курсу.

-	Адаптер (Adapter).  

