using LoginComponent;

DAO db = new DAO();

bool createEmail = db.CreateLogin("hey@email.dk", "123abcABC");

Console.WriteLine($"trying to create email --> {createEmail}");

