﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.ByteBank.WebApp.Testes
{
    public class NavegandoNaPaginaHome
    {
        private IWebDriver driver;

        public NavegandoNaPaginaHome()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Fact]
        public void CarregaPaginaHomeVerificaTituloPagina()
        {
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309");

            //Assert
            Assert.Contains("WebApp", driver.Title);

            driver.Close();
        }

        [Fact]
        public void CarregaPaginaHomeVerificaLoginHome()
        {
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309");

            //Assert
            Assert.Contains("Login", driver.PageSource);
            Assert.Contains("Home", driver.PageSource);

            driver.Close();
        }

        [Fact]
        public void LogandoSistema()
        {
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309/");

            //Assert
            driver.Manage().Window.Size = new System.Drawing.Size(974, 1050);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("rafael@email.com");
            driver.FindElement(By.Id("Senha")).Click();
            driver.FindElement(By.Id("Senha")).SendKeys("senha01");
            driver.FindElement(By.Id("btn-logar")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();

            driver.Close();
        }
        [Fact]
        public void Sistema()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost:44309/");

            var linkLogin = driver.FindElement(By.LinkText("Login"));

            //Act
            linkLogin.Click();

            //Assert
            Assert.Contains("img", driver.PageSource);

            driver.Close();
        }

        [Fact]
        public void AcessarPaginaSemEstarLogado()
        {
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

            //Assert
            Assert.Contains("401", driver.PageSource);

            driver.Close();
        }

        [Fact]
        public void AcessarPaginaSemEstarLogadoVerificaUrl()
        {
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

            //Assert
            Assert.Contains("https://localhost:44309/Agencia/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);

            driver.Close();
        }
    }
}
