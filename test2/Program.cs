using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json;



[TestFixture]
public class TestClass
{
    IWebDriver driver;
    private string _username;
    private string _password;
    
   

    [SetUp]
    public void ReadCredentials()
    {
        string configPath = @"../test2/config.json"; 

        if (File.Exists(configPath))
        {
            try
            {
                string jsonString = File.ReadAllText(configPath);
                dynamic config = JsonConvert.DeserializeObject<dynamic>(jsonString);

                _username = config.username;
                _password = config.password;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error al leer el archivo de configuración: {ex.Message}");
            }
        }
        else
        {
            Assert.Fail("El archivo de configuración no existe.");
        }
    }

  
    [Test,Order(1)]
    public void Login()
    {

        driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers/chromedriver.exe"));
        int tiempoEspera = 2000;

         driver.Navigate().GoToUrl("https://cobogweb10pj.co.kworld.kpmg.com/TLTooL_pj/");
         driver.Manage().Window.Maximize();

        IWebElement usernameInput = driver.FindElement(By.Name("UserName"));
        Thread.Sleep(tiempoEspera);
        usernameInput.SendKeys(_username);


        IWebElement passwordInput = driver.FindElement(By.Id("Password"));
        passwordInput.SendKeys(_password);
        Thread.Sleep(tiempoEspera);
        

        // Encuentra la casilla de verificación por su identificador único
        IWebElement checkbox = driver.FindElement(By.Id("AcceptTerms"));

        Thread.Sleep(tiempoEspera);

        // Verifica si la casilla de verificación está desmarcada
        if (!checkbox.Selected)
        {
            // Marca la casilla de verificación
            checkbox.Click();
        }
       
       driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/form/button")).Click();
       Thread.Sleep(tiempoEspera);
    }

    [Test,Order(2)]
   public void Busquedausers(){

        int tiempoEspera = 2000;


        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[2]/a")).Click();
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[2]/ul/li[1]/a")).Click();
        Thread.Sleep(tiempoEspera);
        IWebElement campoTexto = driver.FindElement(By.Id("search_box"));
        campoTexto.Clear();
        campoTexto.SendKeys("Sanchez A.");
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.XPath("//*[@id='tabla-usuarios']/tbody/tr[1]/td[6]/a[1]")).Click();
        Thread.Sleep(tiempoEspera);
        
    }   

     [Test,Order(3)]
    public void Busquedacliente()
    {

        int tiempoEspera = 2000;

        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[2]/a")).Click();
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[2]/ul/li[2]/a")).Click();
        Thread.Sleep(tiempoEspera);
        IWebElement campoTexto = driver.FindElement(By.Id("search_box"));
        campoTexto.SendKeys("kpmg");
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.XPath("//*[@id='3']/td[4]/a[1]")).Click();
        Thread.Sleep(tiempoEspera);
    }

    [Test,Order(4)]
    public void Busquedamodulos(){

        int tiempoEspera = 2000;
        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[2]/a")).Click();
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[2]/ul/li[3]/a")).Click();
        Thread.Sleep(tiempoEspera);
        IWebElement campoTexto = driver.FindElement(By.Id("search_box"));
        campoTexto.SendKeys("kiv");
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.XPath("//*[@id='12']/td[4]/a")).Click();
        Thread.Sleep(tiempoEspera);
        
    }

    [Test,Order(5)]
    public void Busquedarol(){

        int tiempoEspera = 2000;
        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[2]/a")).Click();
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[2]/ul/li[4]/a")).Click();
        Thread.Sleep(tiempoEspera);
        IWebElement campoTexto = driver.FindElement(By.Id("search_box"));
        campoTexto.SendKeys("kiv");
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.XPath("//*[@id='18']/td[4]/a")).Click();
        Thread.Sleep(tiempoEspera);
        
    }
    [Test,Order(6)]
    public void Busquedapermisos(){

        int tiempoEspera = 2000;
        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[2]/a")).Click();
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[2]/ul/li[5]/a")).Click();
        Thread.Sleep(tiempoEspera);
        IWebElement campoTexto = driver.FindElement(By.Id("search_box"));
        campoTexto.SendKeys("proyecto.ver");
        Thread.Sleep(tiempoEspera);

        
}   [Test,Order(7)]  
    public void auditoria(){
        
        int tiempoEspera = 2000;
        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[3]/a")).Click();
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.XPath("//*[@id='navbar']/ul[1]/li[3]/ul/li/a")).Click();
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.Id("btnBuscar")).Click();
        Thread.Sleep(tiempoEspera);
        driver.FindElement(By.XPath("//*[@id='dtUsuario']/div/div[5]/div/table/tbody/tr[2]/td[4]/div/div[1]/div/ul/li/div/div[1]/i")).Click();
        driver.FindElement(By.XPath("//*[@id='dtUsuario']/div/div[4]/div/div/div[3]/div[1]/div/div")).Click();
        Thread.Sleep(tiempoEspera);
        driver.Quit();
        Thread.Sleep(tiempoEspera);
    }/*
     [TearDown]
    public void Quitar()
    {
        // Cerrar el navegador
       driver.Quit();
    }*/
}
