using Provider;
using Entities;

namespace hw_2
{
    internal class ConsoleMenuWithCRUD
    {
        public static ConsoleColor ForeColorMenu = ConsoleColor.Yellow;
        public static ConsoleColor ForeColorServices = ConsoleColor.Blue;
        public static ConsoleColor ForeColorErrors = ConsoleColor.Red;
        public static ConsoleColor ForeColorDefault = ConsoleColor.White;

        private ReaderRepository _readRep = new ReaderRepository();
        private CategoryRepository _catRep = new CategoryRepository();
        private GenreRepository _genRep = new GenreRepository();
        private BookRepository _bookRep = new BookRepository();
        private IssuedRepository _issuedRep = new IssuedRepository();

        public void Clear()
        {
            Console.Clear();
        }

        public void SetForeground(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void Show(ConsoleColor color, Action action)
        {
            SetForeground(color);
            Console.WriteLine("\n-----------------------------");

            action();

            Console.WriteLine("-----------------------------\n");
            SetForeground(ForeColorDefault);
        }

        public void Message(ConsoleColor color, string text)
        {
            Show(color, () => Console.WriteLine(text));
        }

        public async Task DisplayMainMenu()
        {
            try
            {
                while (true)
                {
                    Clear();

                    Show(ForeColorMenu, () =>
                    {
                        Console.WriteLine("1. Reading file");
                        Console.WriteLine("2. Record file");
                        Console.WriteLine("3. Fibonacci number output");
                        Console.WriteLine("4. Library System");
                        Console.WriteLine("5. Exit");
                    });

                    switch (Console.ReadLine())
                    {
                        case "1":
                            ReadingLines();
                            break;

                        case "2":
                            await RecordFile();
                            break;

                        case "3":
                            Fib();
                            break;

                        case "4":
                            LibrarySystem();
                            break;

                        case "5":
                            SetForeground(ForeColorDefault);
                            return;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadingLines()
        {
            while (true)
            {
                Clear();

                SetForeground(ForeColorServices);

                var formAns = InputTextForm(
                    "Input a fileName: ",
                    "Input a count rows of file: ",
                    "Which line to read from: "
                );

                var fileName = formAns[0];

                int.TryParse(formAns[1], out var count);

                int.TryParse(formAns[2], out var startIndex);

                Show(ForeColorDefault, () =>
                {
                    var file = new FileWorker(fileName);
                    try
                    {
                        file.ReadingFile(count, startIndex - 1);
                    }
                    catch (Exception ex)
                    {
                        Message(ForeColorErrors, ex.Message);
                    }
                });

                var ans = RestartOrExit();
                switch (ans)
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public int RestartOrExit()
        {
            Show(ForeColorMenu, () =>
            {
                Console.WriteLine("1. Restart");
                Console.WriteLine("2. Exit to menu");
            });

            while (true)
            {
                int.TryParse(Console.ReadLine(), out int ans);

                switch (ans)
                {
                    case 1:
                        return 1;
                    case 2:
                        return 2;
                    default:
                        Message(ForeColorErrors, "Error, repeat!");
                        break;
                }
            }
        }

        public void Fib()
        {
            while (true)
            {
                Clear();

                SetForeground(ForeColorServices);

                var formAns = InputTextForm("Input a serial number of Fibonacci: ");

                int.TryParse(formAns[0], out int n);

                Message(ForeColorDefault, ($"The answer is {n.Fibonacci()}"));

                var ans = RestartOrExit();
                switch (ans)
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public void LibrarySystem()
        {
            while(true)
            {
                Clear();

                Show(ForeColorMenu, () =>
                {
                    Console.WriteLine("1. Books");
                    Console.WriteLine("2. Readers");
                    Console.WriteLine("3. Issued");
                    Console.WriteLine("4. Categories");
                    Console.WriteLine("5. Genres");
                    Console.WriteLine("6. Exit to menu");
                });

                switch (Console.ReadLine())
                {
                    case "1":
                        SelectBooksForm();
                        break;

                    case "2":
                        SelectReadersForm();
                        break;

                    case "3":
                        SelectIssuedForm();
                        break;

                    case "4":
                        SelectCategories();
                        break;

                    case "5":
                        SelectGenres();
                        break;

                    case "6":
                        return;

                    default:
                        break;
                }
            }
        }

        public void SelectBooksForm()
        {
            while (true)
            {
                Clear();

                Show(ForeColorMenu, () =>
                {
                    Console.WriteLine("1. Get all books");
                    Console.WriteLine("2. Get book by Id");
                    Console.WriteLine("3. Add book");
                    Console.WriteLine("4. Update book");
                    Console.WriteLine("5. Delete book");
                    Console.WriteLine("6. Exit to menu");
                });

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            _bookRep.GetAll().ForEach(x => Console.WriteLine(x));
                            break;

                        case "2":
                            var s = InputTextForm("Enter the id: ")[0];

                            Console.WriteLine(_bookRep.GetById(Guid.Parse(s)));
                            break;

                        case "3":
                            AddBookForm();
                            break;

                        case "4":
                            UpdateBookFomr();
                            break;

                        case "5":
                            s = InputTextForm("Enter the id: ")[0];

                            _bookRep.DeleteById(Guid.Parse(s));
                            break;

                        case "6":
                            return;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Message(ForeColorErrors, ex.Message);
                }

                var ans = RestartOrExit();
                switch (ans)
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public void AddBookForm()
        {
            var textForm = InputTextForm(
                "Name: ",
                "Author: ",
                "Genre: ",
                "Collateral Value: ",
                "Rental Cost: ",
                "Count of books: "
            );

            textForm.Insert(0, Guid.NewGuid().ToString());

            var str = "";

            textForm.ForEach(x => str += x + " ");

            _bookRep.AddItem(Book.Parse(str));
        }

        public void UpdateBookFomr()
        {
            var id = Guid.Parse(InputTextForm("Enter the id: ")[0]);

            var book = _bookRep.GetById(id);

            var dataForm = InputTextForm(
                $"Name {book.nameBook} for it ",
                $"Author {book.author} for it ",
                $"Genre {book.fk_id_genre} for it ",
                $"Collateral Value {book.collateralValue} for it ",
                $"Rental cost {book.rentalCost} for it ",
                $"Count {book.countBook} for it ");

            dataForm.Insert(0, id.ToString());

            var str = "";

            dataForm.ForEach(x => str += x + " ");

            _bookRep.UpdateItem(Book.Parse(str));
        }

        //
        public void SelectReadersForm()
        {
            while (true)
            {
                Clear();

                Show(ForeColorMenu, () =>
                {
                    Console.WriteLine("1. Get all readers");
                    Console.WriteLine("2. Get reader by Id");
                    Console.WriteLine("3. Add reader");
                    Console.WriteLine("4. Update reader");
                    Console.WriteLine("5. Delete reader");
                    Console.WriteLine("6. Exit to menu");
                });

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            _readRep.GetAll().ForEach(x => Console.WriteLine(x));
                            break;

                        case "2":
                            var s = InputTextForm("Enter the id: ")[0];

                            Console.WriteLine(_readRep.GetById(Guid.Parse(s)));
                            break;

                        case "3":
                            AddReaderForm();
                            break;

                        case "4":
                            UpdateReaderForm();
                            break;

                        case "5":
                            s = InputTextForm("Enter the id: ")[0];

                            _readRep.DeleteById(Guid.Parse(s));
                            break;

                        case "6":
                            return;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Message(ForeColorErrors, ex.Message);
                }

                var ans = RestartOrExit();
                switch (ans)
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public void UpdateReaderForm()
        {
            var id = Guid.Parse(InputTextForm("Enter the id: ")[0]);

            var reader = _readRep.GetById(id);

            var dataForm = InputTextForm(
                $"Last name {reader.lastName} for it ",
                $"First name {reader.firstName} for it ",
                $"Patronymic {reader.patronymic} for it ",
                $"Category {reader.fk_id_category} for it ",
                $"Adress {reader.adress} for it ",
                $"Email {reader.email} for it ");

            dataForm.Insert(0, id.ToString());

            var str = "";

            dataForm.ForEach(x => str += x + " ");

            _readRep.UpdateItem(Reader.Parse(str));
        }

        public void AddReaderForm()
        {
            var textForm = InputTextForm(
                "Last Name: ",
                "First Name: ",
                "Patronymic: ",
                "Category: ",
                "Adress: ",
                "Email: "
            );

            textForm.Insert(0, Guid.NewGuid().ToString());

            var str = "";

            textForm.ForEach(x => str += x + " ");

            _readRep.AddItem(Reader.Parse(str));
        }
        //

        public void SelectIssuedForm()
        {
            while (true)
            {
                Clear();

                Show(ForeColorMenu, () =>
                {
                    Console.WriteLine("1. Get all issued");
                    Console.WriteLine("2. Get issued book by Id");
                    Console.WriteLine("3. Issue a book");
                    Console.WriteLine("4. Change details on issued book");
                    Console.WriteLine("5. Delete issued book");
                    Console.WriteLine("6. Exit to menu");
                });

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            _issuedRep.GetAll().ForEach(x => Console.WriteLine(x));
                            break;

                        case "2":
                            var s = InputTextForm("Enter the id: ")[0];

                            Console.WriteLine(_issuedRep.GetById(Guid.Parse(s)));
                            break;

                        case "3":
                            AddReaderForm();
                            break;

                        case "4":
                            UpdateReaderForm();
                            break;

                        case "5":
                            s = InputTextForm("Enter the id: ")[0];

                            _issuedRep.DeleteById(Guid.Parse(s));
                            break;

                        case "6":
                            return;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Message(ForeColorErrors, ex.Message);
                }

                var ans = RestartOrExit();
                switch (ans)
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public void AddIssuedForm()
        {
            var textForm = InputTextForm(
                "Id reader: ",
                "Id book: ",
                "Date of issue: ",
                "Date of due: "
            );

            textForm.Insert(0, Guid.NewGuid().ToString());

            var str = "";

            textForm.ForEach(x => str += x + " ");

            _issuedRep.AddItem(Issued.Parse(str));
        }

        public void UpdateIssuedForm()
        {
            var id = Guid.Parse(InputTextForm("Enter the id: ")[0]);

            var issued = _issuedRep.GetById(id);

            var dataForm = InputTextForm(
                $"Id reader {issued.fk_id_reader} for it ",
                $"Id book {issued.fk_id_book} for it ",
                $"Date of issue {issued.date_issue} for it ",
                $"Date of due {issued.date_due} for it ");

            dataForm.Insert(0, id.ToString());

            var str = "";

            dataForm.ForEach(x => str += x + " ");

            _issuedRep.UpdateItem(Issued.Parse(str));
        }
        //

        //
        public void SelectCategories()
        {
            while (true)
            {
                Clear();

                Show(ForeColorMenu, () =>
                {
                    Console.WriteLine("1. Get all categories");
                    Console.WriteLine("2. Get category by Id");
                    Console.WriteLine("3. Add category");
                    Console.WriteLine("4. Update category");
                    Console.WriteLine("5. Delete category");
                    Console.WriteLine("6. Exit to menu");
                });

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            _catRep.GetAll().ForEach(x => Console.WriteLine(x));
                            break;

                        case "2":
                            var s = int.Parse(InputTextForm("Enter the id: ")[0]);

                            Console.WriteLine(_catRep.GetById(s));
                            break;

                        case "3":
                            AddCategoryForm();
                            break;

                        case "4":
                            UpdateCategoryForm();
                            break;

                        case "5":
                            s = int.Parse(InputTextForm("Enter the id: ")[0]);

                            _catRep.DeleteById(s);
                            break;

                        case "6":
                            return;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Message(ForeColorErrors, ex.Message);
                }

                var ans = RestartOrExit();
                switch (ans)
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public void AddCategoryForm()
        {
            var cat = new Category { name = InputTextForm("Name: ")[0] };

            _catRep.AddItem(cat);
        }

        public void UpdateCategoryForm()
        {
            var id = int.Parse(InputTextForm("Enter the id: ")[0]);

            var c = _catRep.GetById(id);

            var dataForm = InputTextForm($"Name {c.name} for it ")[0];

            _catRep.UpdateItem(new Category(id, dataForm));
        }
        //

        //
        public void SelectGenres()
        {
            while (true)
            {
                Clear();

                Show(ForeColorMenu, () =>
                {
                    Console.WriteLine("1. Get all genres");
                    Console.WriteLine("2. Get genre by Id");
                    Console.WriteLine("3. Add genre");
                    Console.WriteLine("4. Update genre");
                    Console.WriteLine("5. Delete genre");
                    Console.WriteLine("6. Exit to menu");
                });

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            _genRep.GetAll().ForEach(x => Console.WriteLine(x));
                            break;

                        case "2":
                            var id = int.Parse(InputTextForm("Enter the id: ")[0]);

                            Console.WriteLine(_genRep.GetById(id));
                            break;

                        case "3":
                            AddGenreForm();
                            break;

                        case "4":
                            UpdateGenreForm();
                            break;

                        case "5":
                            id = int.Parse(InputTextForm("Enter the id: ")[0]);

                            _genRep.DeleteById(id);
                            break;

                        case "6":
                            return;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Message(ForeColorErrors, ex.Message);
                }

                var ans = RestartOrExit();
                switch (ans)
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public void AddGenreForm()
        {
            var g = new Genre { nameGenre = InputTextForm("Name: ")[0] };

            _genRep.AddItem(g);
        }

        public void UpdateGenreForm()
        {
            var id = int.Parse(InputTextForm("Enter the id: ")[0]);

            var g = _genRep.GetById(id);

            var dataForm = InputTextForm($"Name {g.nameGenre} for it ")[0];

            _genRep.UpdateItem(new Genre(id, dataForm));
        }
        //

        public List<string?> InputTextForm(params string[] str)
        {
            var listStr = new List<string?>();

            Show(ForeColorServices, () =>
            {
                foreach (var line in str)
                {
                    Console.Write(line);

                    listStr.Add(Console.ReadLine());
                }
            });

            return listStr;
        }

        public async Task RecordFile()
        {
            while (true)
            {
                Clear();

                SetForeground(ForeColorServices);

                var formAns = InputTextForm(
                    "Input a name of file: ",
                    "Input the URL of site: "
                );

                SetForeground(ForeColorDefault);

                var file = new FileWorker(formAns[0]);

                try
                {
                    await file.RecordHtmlToFile(formAns[1]);

                    Message(ForeColorDefault, "Data is loaded!");
                }
                catch (Exception ex)
                {
                    Message(ForeColorErrors, ex.Message);
                }

                var ans = RestartOrExit();
                switch (ans)
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }
    }
}
