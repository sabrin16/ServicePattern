using System;
using System.Collections.Generic;
using Business.Models;
using Business.Services;
using Business.Exceptions;

class Program
{
    static void Main(string[] args)
    {
        var userService = new UserService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Huvudmeny");
            Console.WriteLine("1. Lägg till en användare");
            Console.WriteLine("2. Visa alla användare");
            Console.WriteLine("3. Hämta en användare via ID");
            Console.WriteLine("4. Avsluta");
            Console.Write("Välj ett alternativ: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":

                    AddUser(userService);
                    break;
                case "2":

                    ShowAllUsers(userService);
                    break;
                case "3":
                    GetUserById(userService);
                    break;
                case "4":
                    Console.WriteLine("Avslutar programmet...");
                    return;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    static void AddUser(UserService userService)
    {
        Console.Clear();
        Console.WriteLine("Lägg till en ny användare:");
        Console.Write("Ange namn: ");
        var name = Console.ReadLine();

        Console.Write("Ange roll (Admin eller Regular): ");
        var role = Console.ReadLine();

        UserBase user;
        if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
        {
            user = new AdminUser { Name = name };
        }
        else if (role.Equals("Regular", StringComparison.OrdinalIgnoreCase))
        {
            user = new RegularUser { Name = name };
        }
        else
        {
            Console.WriteLine("Ogiltig roll. Försöker igen.");
            Console.ReadKey();
            return;
        }

        userService.AddUser(user);
        Console.WriteLine($"Användaren {name} med rollen {role} har lagts till.");
        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }

    static void ShowAllUsers(UserService userService)
    {
        Console.Clear();
        Console.WriteLine("Alla användare:");
        var users = userService.GetAllUsers();
        if (users.Count == 0)
        {
            Console.WriteLine("Inga användare hittades.");
        }
        else
        {
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Namn: {user.Name}, Roll: {user.GetRole()}");
            }
        }
        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }

        static void GetUserById(UserService userService)
        {
        Console.Clear();
        Console.Write("Ange ID för användaren: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            try
            {
                var user = userService.GetUserById(id);
                Console.WriteLine($"Användare hittad: ID: {user.Id}, Namn: {user.Name}, Roll: {user.GetRole()}");
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine($"Fel: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Ogiltigt ID. Försöker igen.");
        }
        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }
}