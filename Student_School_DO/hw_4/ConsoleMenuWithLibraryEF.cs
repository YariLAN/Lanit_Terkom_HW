using EntitiesEF;
using hw_2;
using Repositories;
using System.ComponentModel;

namespace hw_4
{
    public class ConsoleMenuWithLibraryEF: ConsoleMenu
    {
        private BookRepository _bkRep;
        private ReaderRepository _rdRep;
        private CategoryRepository _ctRep;
        private GenreRepository _gnRep;
        private IssuedRepository _isRep;

        public ConsoleMenuWithLibraryEF(): base()
        {
            _bkRep = new BookRepository();
            _rdRep = new ReaderRepository();
            _ctRep = new CategoryRepository();
            _gnRep = new GenreRepository();
            _isRep = new IssuedRepository();
        }

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
                            LibraryForm();
                            break;

                        case "5":
                            SetForeground(ForeColorDefault);
                            return;

                        default:
                            break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void LibraryForm()
        {
            while (true)
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
                        SelectCategoryForm();
                        break;

                    case "5":
                        SelectGenreForm();
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
                            GetAllForm(_bkRep);
                            break;

                        case "2":
                            GetByIdForm(_bkRep);
                            break;

                        case "3":
                            var book = new Book();
                            AddItemForm(_bkRep, book,
                                nameof(book.Name),
                                nameof(book.Author),
                                nameof(book.GenreId),
                                nameof(book.CollateralValue),
                                nameof(book.RentalCost),
                                nameof(book.CountBook));

                            break;

                        case "4":
                            UpdateForm(_bkRep, book = new Book(),
                                nameof(book.Name),
                                nameof(book.Author),
                                nameof(book.GenreId),
                                nameof(book.CollateralValue),
                                nameof(book.RentalCost),
                                nameof(book.CountBook));

                            break;

                        case "5":
                            DeleteForm(_bkRep);
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

                switch (RestartOrExit())
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

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
                            GetAllForm(_rdRep);
                            break;

                        case "2":
                            GetByIdForm(_rdRep);
                            break;

                        case "3":
                            var r = new Reader();
                            AddItemForm(_rdRep, r,
                                nameof(r.LastName),
                                nameof(r.FirstName),
                                nameof(r.Patronymic),
                                nameof(r.CategoryId),
                                nameof(r.Adress),
                                nameof(r.Email)
                            );

                            break;

                        case "4":
                            UpdateForm(_rdRep, r = new Reader(),
                                nameof(r.LastName),
                                nameof(r.FirstName),
                                nameof(r.Patronymic),
                                nameof(r.CategoryId),
                                nameof(r.Adress),
                                nameof(r.Email));
                            break;

                        case "5":
                            DeleteForm(_rdRep);
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

                switch (RestartOrExit())
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

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
                            GetAllForm(_isRep);
                            break;

                        case "2":
                            GetByIdForm(_isRep);
                            break;

                        case "3":
                            var i = new Issued();
                            AddItemForm(_isRep, i,
                                nameof(i.ReaderId),
                                nameof(i.BookId),
                                nameof(i.DateIssue),
                                nameof(i.DateDue)
                            );

                            break;

                        case "4":
                            UpdateForm(_isRep, i = new Issued(),
                                nameof(i.ReaderId),
                                nameof(i.BookId),
                                nameof(i.DateIssue),
                                nameof(i.DateDue));

                            break;

                        case "5":
                            DeleteForm(_isRep);
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

                switch (RestartOrExit())
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public void SelectCategoryForm()
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
                            GetAllForm(_ctRep);
                            break;

                        case "2":
                            GetByIdForm(_ctRep);
                            break;

                        case "3":
                            var c = new Category();
                            AddItemForm(_ctRep, c, nameof(c.Name));
                            break;

                        case "4":
                            UpdateForm(_ctRep, c = new Category(), nameof(c.Name));
                            break;

                        case "5":
                            DeleteForm(_ctRep);
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

                switch (RestartOrExit())
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public void SelectGenreForm()
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
                            GetAllForm(_gnRep);
                            break;

                        case "2":
                            GetByIdForm(_gnRep);
                            break;

                        case "3":
                            var g = new Genre();

                            AddItemForm(_gnRep, g, nameof(g.Name));
                            break;

                        case "4":
                            UpdateForm(_gnRep, g = new Genre(), nameof(g.Name));
                            break;

                        case "5":
                            DeleteForm(_gnRep);
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

                switch (RestartOrExit())
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public void AddItemForm<T,id>(IBaseRepository<T, id> rep, IEntity<T> entity, params string[] nameOf)
        {
            var textForm = InputTextForm(nameOf.Select(x => x + ": ").ToArray());

            if (typeof(id) == typeof(Guid))
            {
                textForm.Insert(0, Guid.NewGuid().ToString());
            }

            var str = "";

            textForm.ForEach(x => str += x + " ");

            rep.AddItem(entity.Parse(str));
        }

        public void GetAllForm<T, id>(IBaseRepository<T, id> rep)
        {
            Show(ForeColorDefault, () =>
            {
                rep.GetAll().ForEach(x => Console.WriteLine(x));
            });
        }

        public id IdIdentificator<T, id>(string inputId, IBaseRepository<T, id> rep)
        {
            return (id)TypeDescriptor.GetConverter(typeof(id)).ConvertFromInvariantString(inputId);
        }

        public T? GetByIdForm<T, id>(IBaseRepository<T, id> rep)
        {
            var inputId = InputTextForm("Enter the id: ")[0];

            id getId = IdIdentificator(inputId, rep);

            var ent = rep.GetById(getId);

            Message(ForeColorDefault, ent.ToString());

            return ent;
        }

        public void DeleteForm<T, id>(IBaseRepository<T, id> rep)
        {
            var inputId = InputTextForm("Enter the id: ")[0];

            id getId = IdIdentificator(inputId, rep);

            rep.DeleteById(getId);
        }

        public void UpdateForm<T, id>(IBaseRepository<T, id> rep, IEntity<T> entity, params string[] fields)
        {
            var ent = GetByIdForm(rep);

            var textForm = InputTextForm(fields.Select(x => $"{x}: ").ToArray());

            var concat = "";

            textForm.Insert(0, ent.ToString().Split(" ")[0]);

            textForm.ForEach(x => concat += x + " ");

            rep.UpdateItem(entity.Parse(concat));
        }
    }
}
