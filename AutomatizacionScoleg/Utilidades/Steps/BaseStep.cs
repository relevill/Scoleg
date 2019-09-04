using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System.Reflection;
using System;
using OpenQA.Selenium;
using System.Text;
using AutomatizacionScoleg.Pages.M01_Transversal;

namespace AutomatizacionScoleg.Utilidades.Steps
{
    [Binding]
    public class BaseStep
    {
        #region Variables de la clase

        private static ExtentReports extent;

        private static ExtentTest feature;

        private static ExtentTest scenario;

        #endregion

        #region Métodos de la clase
        /// <summary>
        /// Validar login
        /// </summary>
        private static void ValidarInicioFeature()
        {

            try
            {
                string RutUsuario = ParametrosEjecucion.Usuario;
                string Password = ParametrosEjecucion.Password;

                if (PropiedadDriver.GetDriver != null)
                {
                    var featureActual = (FeatureContext.Current.FeatureInfo.Title);

                    if (featureActual == "M01 Transversal_S01 Sesion")
                    {
                        {
                            PropiedadDriver.GetDriver.Manage().Window.Maximize();
                            PropiedadDriver.GetDriver.Navigate().GoToUrl(ParametrosEjecucion.RutaDelSitio);
                        }
                    }
                    else
                    {
                        PropiedadDriver.GetDriver.Manage().Window.Maximize();
                        PropiedadDriver.GetDriver.Navigate().GoToUrl(ParametrosEjecucion.RutaDelSitio);
                        LoginPage elementosLogin = new LoginPage();
                        System.Threading.Thread.Sleep(2000);
                        elementosLogin.txtRutUsuario.SendKeys(RutUsuario);
                        elementosLogin.txtPassword.SendKeys(Password);
                        elementosLogin.btnLogin.Click();
                        System.Threading.Thread.Sleep(2000);

                        if (PropiedadDriver.GetDriver.Url != ParametrosEjecucion.RutaDelSitio + "/Login/Login/Home")
                        {
                            throw new ExcepcionPrueba("Error al iniciar sesión en la aplicación");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("El navegador no ha podido ser inicializado");
            }
        }

        /// <summary>
        /// Salir del navegador
        /// </summary>
        private static void SalirNavegador()
        {
            try
            {
                PropiedadDriver.GetDriver.Quit();
                PropiedadDriver.Dispose();
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido cerrar el navegador");
            }
        }

        /// <summary>
        /// Obtener la ruta para guardar reporte
        /// </summary>
        private static string GetSavePathReport()
        {
            try
            {
                string pathProject = AppDomain.CurrentDomain.BaseDirectory;
                string pathReport = pathProject.Replace("\\bin\\Debug", "");
                string path = pathReport + "\\Reporte\\";

                return path;

            }
            catch (Exception)
            {
                throw new Exception("No se ha obtenido ruta para guardar reporte");
            }
        }

        /// <summary>
        /// Obtener el detalle del paso
        /// </summary>
        private static string GetStepType()
        {
            try
            {
                string stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

                return stepType;
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener la información del paso");
            }
        }

        /// <summary>
        /// Obtener resultado de la prueba
        /// </summary>
        /// <returns>The test result.</returns>
        private static string GetTestResult()
        {
            try
            {
                PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);

                MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);

                object TestResult = getter.Invoke(ScenarioContext.Current, null);

                return TestResult.ToString();
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el resultado de la prueba");
            }
        }

        /// <summary>
        /// Realizar captura de pantalla
        /// </summary>
        public static String TakesScreenshot(IWebDriver driver, string FileName)
        {

            string pathProject = AppDomain.CurrentDomain.BaseDirectory;
            string pathScreen = pathProject.Replace("\\bin\\Debug", "");
            string path = pathScreen + "Reporte/Capturas defectos/";

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", ".");
            TimeAndDate.Replace(":", ".");
            TimeAndDate.Replace(" ", ".");

            string imageName = TimeAndDate.ToString() + "_" + FileName;

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(path + imageName + "." + System.Drawing.Imaging.ImageFormat.Jpeg);

            return path + imageName + "." + "jpeg";
        }

        /// <summary>
        /// Configuración
        /// </summary>
        [BeforeTestRun]
        public static void SetUp()
        {
            try
            {
                //Customizar Reporte
                var htmlReporter = new ExtentHtmlReporter(GetSavePathReport());

                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
                htmlReporter.Config.ReportName = "Automatización de Pruebas Legal Partner";
                htmlReporter.Config.EnableTimeline = false;

                extent = new ExtentReports();

                extent.AddSystemInfo("Sistema", "Legal Partner");
                extent.AddSystemInfo("Ambiente", "QA");
                extent.AddSystemInfo("Versión Selenium", "3.141.0.0");

                extent.AttachReporter(htmlReporter);

            }
            catch (Exception)
            {
                throw new Exception("Error al iniciar el reporte");
            }

        }

        /// <summary>
        /// Obtener el nombre del feature
        /// </summary>
        [BeforeFeature]
        public static void GetNameFeature()
        {
            try
            {
                ValidarInicioFeature();
                feature = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            }
            catch (ExcepcionPrueba)
            {
                throw new ExcepcionPrueba("El nombre del feature no ha podido ser capturado para el reporte");
            }
        }

        /// <summary>
        /// Gets the name scenario.
        /// </summary>
        [BeforeScenario]
        public void GetNameScenario()
        {
            try
            {
                scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            }
            catch (Exception)
            {
                throw new Exception("El nombre del escenario no ha podido ser capturado para el reporte");
            }
        }

        /// <summary>
        /// Obtener resultado de la prueba
        /// </summary>
        [AfterStep]
        public static void GetResultStep()
        {
            try
            {
                //Passed Status
                if (GetTestResult() == "OK")
                {
                    switch (GetStepType())
                    {
                        case "Given":
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                            break;
                        case "When":
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                            break;
                        case "Then":
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                            break;
                        case "And":
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                            break;
                    }
                }
                //Fail Status
                else if (GetTestResult() == "TestError")
                {
                    switch (GetStepType())
                    {
                        case "Given":
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                            break;
                        case "When":
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                            break;
                        case "Then":
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                            break;
                        case "And":
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                            break;

                    }
                    string screenShotPath = TakesScreenshot(PropiedadDriver.GetDriver, ("Fallo en Feature " + FeatureContext.Current.FeatureInfo.Title));
                    scenario.AddScreenCaptureFromPath(screenShotPath);
                }
                //Pending Status            
                if (GetTestResult() == "StepDefinitionPending")
                {
                    switch (GetStepType())
                    {
                        case "Given":
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                            break;
                        case "When":
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                            break;
                        case "Then":
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                            break;
                        case "And":
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                            break;
                    }
                }
            }
            catch (ExcepcionPrueba)
            {
                throw new ExcepcionPrueba("El nombre del paso no ha podido ser capturado para el reporte");
            }
        }

        /// <summary>
        /// Tears down.
        /// </summary>
        [AfterFeature]
        public static void TearDown()
        {
            try
            {
                //Save report
                extent.Flush();

                SalirNavegador();
            }
            catch (Exception)
            {
                throw new Exception("El reporte no se ha guardado");
            }
        }
        #endregion
    }
}