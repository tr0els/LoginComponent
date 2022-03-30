using LoginComponent;
using LoginComponent.util;
using System.Security.Cryptography;

LoginService ls = new LoginService(new DAO(), new EmailAndPasswordValidator());
