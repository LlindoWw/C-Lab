using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIK_BIBOS
{
    class Contacts
    {
        public string surname;
        public string name;
        public string middlename;
        public string number;
        public string country;
        public string birthday;
        public string organization;
        public string position;
        public string other;

        public Contacts(
            string surname,
            string name,
            string middlename,
            string number,
            string country,
            string birthday,
            string organization,
            string position,
            string other)
        {
            this.surname = surname;
            this.name = name;
            this.middlename = middlename;
            this.number = number;
            this.country = country;
            this.birthday = birthday;
            this.organization = organization;
            this.position = position;
            this.other = other;
        }
    }

    class NoteBook
    {
        List<Contacts> contacts;

        public NoteBook()
        {
            contacts = new List<Contacts>();
        }

        public void add(
            string surname,
            string name,
            string middlename,
            string number,
            string country,
            string birthday,
            string organization,
            string position,
            string other)
        {
            Contacts date = new Contacts(surname, name, middlename, number, country, birthday, organization, position, other);
            contacts.Add(date);
        }

        public bool remove(string name)
        {
            Contacts date = find(name);

            if (date != null)
            {
                contacts.Remove(date);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void list(Action<Contacts> action)
        {
            contacts.ForEach(action);
        }

        public bool isEmpty()
        {
            return (contacts.Count == 0);
        }
        public bool find2(string name)
        {
            Contacts date = contacts.Find(
              delegate (Contacts a)
              {
                  return a.name == name;
              }
            );
            Contacts date1 = contacts.FindLast(
             delegate (Contacts a)
             {
                 return a.name == name;
             }
           );
            if (date1 == date)
                return true;
            else
                return false;
        }

        public Contacts find(string name)
        {
            Contacts date = contacts.Find(
              delegate (Contacts a)
              {
                  return a.name == name;
              }
            );
            return date;
        }
        public Contacts findwiths(string name, string surname)
        {
            Contacts date = contacts.Find(
              delegate (Contacts a)
              {
                  return (a.name == name && a.surname == surname);
              }
            );
            return date;
        }
    }

    class NoteBookMain
    {
        NoteBook book;

        public NoteBookMain()
        {
            book = new NoteBook();
        }

        static void Main(string[] args)
        {
            int menu = 0;
            NoteBookMain prompt = new NoteBookMain();
            do
            {

                Console.WriteLine("Главное меню");
                Console.WriteLine("1)Добавить контакт");
                Console.WriteLine("2)Изменить контакт");
                Console.WriteLine("3)Удалить контакт");
                Console.WriteLine("4)Вывести список всех контактов");
                Console.WriteLine("5)Вывести контакт");
                Console.WriteLine("6)Выход");
                Console.WriteLine("***************************************");
                int.TryParse(Console.ReadLine(), out menu);
                prompt.performAction(menu);
                Console.Clear();
            }
            while (menu != 6);
        }

        void performAction(int menu)
        {
            string surname;
            string name;
            string middlename;
            string number;
            string country;
            string birthday;
            string organization;
            string position;
            string other;

            switch (menu)
            {
                case 1:

                    Console.WriteLine("Введите фамилию: ");
                    surname = Console.ReadLine();
                    while (surname == "")
                    {
                        Console.WriteLine("Ошибка, нет фамилии");
                        surname = Console.ReadLine();
                    }
                    Console.WriteLine("Введите имя:");
                    name = Console.ReadLine();
                    while (name == "")
                    {
                        Console.WriteLine("Ошибка, нет имени");
                        name = Console.ReadLine();
                    }
                    Console.WriteLine("Введите отчество: ");
                    middlename = Console.ReadLine();
                    Console.WriteLine("Номер телефона:");
                    long result;
                    number = Console.ReadLine();
                    while (number == "")
                    {
                        Console.WriteLine("Ощибка, введите номер:");
                        number = Console.ReadLine();
                    }
                    result = Convert.ToInt64(number);
                    Console.WriteLine("Введите страну: ");
                    country = Console.ReadLine();
                    while (country == "")
                    {
                        Console.WriteLine("Ошибка, введите страну: ");
                        country = Console.ReadLine();
                    }
                    Console.WriteLine("Введите дату рождения: ");
                    birthday = Console.ReadLine();
                    Console.WriteLine("Введите организацию: ");
                    organization = Console.ReadLine();
                    Console.WriteLine("Введите должность: ");
                    position = Console.ReadLine();
                    Console.WriteLine("Ввести другое: ");
                    other = Console.ReadLine();
                    book.add(surname, name, middlename, number, country, birthday, organization, position, other);
                    Console.WriteLine("Контакт успешно создан!");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Введите имя изменяемой записи: ");
                    name = Console.ReadLine();
                    Contacts date;
                    if (book.find2(name))
                        date = book.find(name);
                    else
                    {
                        Console.WriteLine("Введите фамилию изменяемой записи: ");
                        surname = Console.ReadLine();
                        date = book.findwiths(name, surname);
                    }

                    if (date == null)
                    {
                        Console.WriteLine("Контакт для {0} не найден.", name);
                        Console.ReadKey();
                    }
                    else
                    {
                        string edition = "";
                        NoteBookMain edit = new NoteBookMain();
                        Console.WriteLine("Введите редактируемые значения: ");
                        edition = Console.ReadLine();
                        edit.performAction(menu);
                        switch (edition)
                        {
                            case "surname":
                                Console.WriteLine("Введите новую фамилию: ");
                                date.surname = Console.ReadLine();
                                Console.WriteLine("Контакт для {0} обновлён", name);
                                break;
                            case "name":
                                Console.WriteLine("Введите новую имя: ");
                                date.name = Console.ReadLine();
                                Console.WriteLine("Контакт для {0} обновлён", name);
                                break;
                            case "patronymic":
                                Console.WriteLine("Введите новую отчество: ");
                                date.middlename = Console.ReadLine();
                                Console.WriteLine("Контакт для {0} обновлён", name);
                                break;
                            case "number":
                                Console.WriteLine("Введите новый номер: ");
                                date.number = Console.ReadLine();
                                Console.WriteLine("Контакт для {0} обновлён", name);
                                break;
                            case "country":
                                Console.WriteLine("Введите новую страну: ");
                                date.country = Console.ReadLine();
                                Console.WriteLine("Контакт для {0} обновлён", name);
                                break;
                            case "birthday":
                                Console.WriteLine("Введите новую дату рождения: ");
                                date.birthday = Console.ReadLine();
                                Console.WriteLine("Контакт для {0} обновлён", name);
                                break;
                            case "organization":
                                Console.WriteLine("Введите новую организацию: ");
                                date.organization = Console.ReadLine();
                                Console.WriteLine("Контакт для {0} обновлён", name);
                                break;
                            case "post":
                                Console.WriteLine("Введите новую должность: ");
                                date.position = Console.ReadLine();
                                Console.WriteLine("Контакт для {0} обновлён", name);
                                break;
                            case "other":
                                Console.WriteLine("Введите новое другое: ");
                                date.other = Console.ReadLine();
                                Console.WriteLine("Контакт для {0} обновлён", name);
                                break;
                        }
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Введите контакт для удаления: ");
                    name = Console.ReadLine();
                    if (book.remove(name))
                    {
                        Console.WriteLine("Контакт успешно удалён");
                    }
                    else
                    {
                        Console.WriteLine("Контакт для {0} не найден.", name);
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    if (book.isEmpty())
                    {
                        Console.WriteLine("Нет записей.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Контакты:");
                        book.list(
                          delegate (Contacts a)
                          {
                              Console.WriteLine("{0} - {1} - {2}", a.surname, a.name, a.number);
                          }
                        );
                    }
                    Console.ReadKey();
                    break;
                case 5:
                    Console.WriteLine("Введите имя для поиска: ");
                    name = Console.ReadLine();
                    Contacts find;
                    if (book.find2(name))
                        find = book.find(name);
                    else
                    {
                        Console.WriteLine("Введите фамилию для поиска: ");
                        surname = Console.ReadLine();
                        find = book.findwiths(name, surname);
                    }
                    if (find == null)
                    {
                        Console.WriteLine("Контакт для {0} не найден.", name);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Контакт:");
                        Console.WriteLine("Фамилия:{0}, Имя:{1}, Отчество:{2}, Мобила:{3},Страна:{4}, Дата рождения:{5}, Организация:{6}, Должность:{7}, Другое:{8}"
                            , find.surname, find.name, find.middlename, find.number, find.country, find.birthday, find.organization, find.position, find.other);
                    }
                    Console.ReadKey();
                    break;
            }
        }
    }
}