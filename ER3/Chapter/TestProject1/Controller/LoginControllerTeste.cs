using Chapter.Controllers;
using Chapter.Interfaces;
using Chapter.ViewModels;
using Chapter.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.IdentityModel.Tokens.Jwt;

namespace TestProject1.Controller
{
    public class LoginControllerTeste
    {
        [Fact]
        public void LoginController_Retornar_Usuario_Invalido()
        {
            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            LoginVIewModel dadosLogin = new LoginVIewModel();
            dadosLogin.Email = "email@e.com";
            dadosLogin.Senha = "123";

            var controller = new LoginController(fakeRepository.Object);
            var resultado = controller.Login(dadosLogin);

            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void LoginController_Retornar_Token()
        {
            Usuario usuarioRetorno = new Usuario();
            usuarioRetorno.Email = "email@e.com";
            usuarioRetorno.Senha = "1234";
            usuarioRetorno.Tipo = "0";

            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioRetorno);

            string IssuerValidacao = "chapter.webapi";

            LoginVIewModel dadosLogin = new LoginVIewModel();
            dadosLogin.Email = "sorvete";
            dadosLogin.Senha = "123";

            var controller = new LoginController(fakeRepository.Object);
            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosLogin);

            string token = resultado.Value.ToString().Split(' ')[3];
            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenJwt = jwtHandler.ReadJwtToken(token);

            Assert.Equal(IssuerValidacao, tokenJwt.Issuer);
        }
    }
}
