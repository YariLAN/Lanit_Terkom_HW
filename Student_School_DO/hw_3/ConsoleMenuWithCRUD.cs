using Provider;
using Entities;
using hw_2;

namespace hw_3
{
    public class ConsoleMenuWithCRUD: ConsoleMenu
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

        public override async Task DisplayMainMenu()
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
                    Console.WriteLine("4. Categories of readers");
                    Console.WriteLine("5. Genres of books");
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
                            var book = new Book();

                            AddItemForm(_bookRep, book,
                                nameof(book.Name),
                                nameof(book.Author),
                                nameof(book.GenreId),
                                nameof(book.CollateralValue),
                                nameof(book.RentalCost),
                                nameof(book.CountBook)
                            );
                            break;

                        case "4":
                            UpdateBookForm();
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

        public void AddItemForm<T, id>(
            InterfaceRepository<T, id> repository,
            EntityInterface<T> entity,
            params string[] nameOf)
        {
            var textForm = InputTextForm(nameOf.Select(x => x + ": ").ToArray());

            if (typeof(id) == typeof(Guid))
            {
                textForm.Insert(0, Guid.NewGuid().ToString());
            }

            var str = "";

            textForm.ForEach(x => str += x + " ");

            repository.AddItem(entity.Parse(str));
        }

        public void UpdateBookForm()
        {
            var id = Guid.Parse(InputTextForm("Enter the id: ")[0]);

            var book = _bookRep.GetById(id);

            var dataForm = InputTextForm(
                $"Name {book.Name} for it ",
                $"Author {book.Author} for it ",
                $"Genre {book.GenreId} for it ",
                $"Collateral Value {book.CollateralValue} for it ",
                $"Rental cost {book.RentalCost} for it ",
                $"Count {book.CountBook} for it ");

            dataForm.Insert(0, id.ToString());

            var str = "";

            dataForm.ForEach(x => str += x + " ");

            _bookRep.UpdateItem(new Book().Parse(str));
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
                            var r = new Reader();

                            AddItemForm(_readRep, r,
                                nameof(r.LastName),
                                nameof(r.FirstName),
                                nameof(r.Patronymic),
                                nameof(r.CategoryId),
                                nameof(r.Adress),
                                nameof(r.Email)
                            );
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
                $"Last name {reader.LastName} for it ",
                $"First name {reader.FirstName} for it ",
                $"Patronymic {reader.Patronymic} for it ",
                $"Category {reader.CategoryId} for it ",
                $"Adress {reader.Adress} for it ",
                $"Email {reader.Email} for it ");

            dataForm.Insert(0, id.ToString());

            var str = "";

            dataForm.ForEach(x => str += x + " ");

            _readRep.UpdateItem(reader.Parse(str));
        }
        //

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
                            var i = new Issued();

                            AddItemForm(_issuedRep, i,
                                nameof(i.ReaderId),
                                nameof(i.BookId),
                                nameof(i.DateIssue),
                                nameof(i.DateDue)
                            );
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

        public void UpdateIssuedForm()
        {
            var id = Guid.Parse(InputTextForm("Enter the id: ")[0]);

            var issued = _issuedRep.GetById(id);

            var dataForm = InputTextForm(
                $"Id reader {issued.ReaderId} for it ",
                $"Id book {issued.BookId} for it ",
                $"Date of issue {issued.DateIssue} for it ",
                $"Date of due {issued.DateDue} for it ");

            dataForm.Insert(0, id.ToString());

            var str = "";

            dataForm.ForEach(x => str += x + " ");

            _issuedRep.UpdateItem(new Issued().Parse(str));
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
                            var c = new Category();

                            AddItemForm(_catRep, c, nameof(c.Name));
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

        public void UpdateCategoryForm()
        {
            var id = int.Parse(InputTextForm("Enter the id: ")[0]);

            var c = _catRep.GetById(id);

            var dataForm = InputTextForm($"Name {c.Name} for it ")[0];

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
                            var g = new Genre();

                            AddItemForm(_genRep, g, nameof(g.Name));
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

        public void UpdateGenreForm()
        {
            var id = int.Parse(InputTextForm("Enter the id: ")[0]);

            var g = _genRep.GetById(id);

            var dataForm = InputTextForm($"Name {g.Name} for it ")[0];

            _genRep.UpdateItem(new Genre(id, dataForm));
        }
        //
    }
}
