﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AutomatizacionScoleg.Features.M02Adm_Usuarios
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("M02 Adm. Usuarios_S02 Perfil")]
    public partial class M02Adm_Usuarios_S02PerfilFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "M02 Adm. Usuarios_S02 Perfil.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("es"), "M02 Adm. Usuarios_S02 Perfil", "\tMacro Proceso Administrador\r\n\tProceso Administrador de usuarios\r\n\tSubProceso Per" +
                    "fil", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("CP01_Listar Grupo")]
        public virtual void CP01_ListarGrupo()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CP01_Listar Grupo", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
testRunner.Given("El usuario ingresa a la opción de menú Listar Perfil", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 8
testRunner.Then("El sistema despliega una grilla con los registros de los perfiles existentes en e" +
                    "l sistema", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entonces ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("CP02_Ingresar Perfil")]
        [NUnit.Framework.TestCaseAttribute("TestGrupoAut1", "Informes Operativos", new string[] {
                "source:M02_Adm.Usuarios.xlsx:INGRESAR.PERFIL"}, Category="source:M02_Adm.Usuarios.xlsx:INGRESAR.PERFIL")]
        public virtual void CP02_IngresarPerfil(string descripcion, string grupo, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CP02_Ingresar Perfil", exampleTags);
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("El usuario ingresa a la opción de menú Ingresar Perfil", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 12
 testRunner.And("El sistema despliega el formulario para ingresar perfil", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 13
 testRunner.When(string.Format("El usuario ingresa la descripción {0} y selecciona el grupo {1}", descripcion, grupo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Cuando ");
#line 14
 testRunner.And("El usuario pulsa el botón Registrar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 15
 testRunner.And("El usuario confirma el ingreso del registro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 16
 testRunner.Then(string.Format("El sistema despliega en la grilla el registro ingresado con la descripción {0}", descripcion), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entonces ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("CP03_Editar Perfil")]
        [NUnit.Framework.TestCaseAttribute("TestGrupoAut1", "Informes Operativos", "", "", new string[] {
                "source:M02_Adm.Usuarios.xlsx:EDITAR.PERFIL"}, Category="source:M02_Adm.Usuarios.xlsx:EDITAR.PERFIL")]
        public virtual void CP03_EditarPerfil(string descripcionSearch, string grupoSearch, string descripcionEdit, string grupoEdit, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CP03_Editar Perfil", exampleTags);
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given("El usuario ingresa a la opción de menú Listar Perfil", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 24
 testRunner.And(string.Format("El usuario pulsa el botón Editar para el registro con descripción {0}", descripcionSearch), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 25
 testRunner.And(string.Format("El sistema despliega el formulario para editar perfil y con la siguiente informac" +
                        "ión: descripción {0}, grupo <Grupo>", descripcionSearch), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 26
 testRunner.When(string.Format("El usuario modifica la descripción por {0} y selecciona el grupo {1}", descripcionEdit, grupoEdit), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Cuando ");
#line 27
 testRunner.And("El usuario pulsa el botón Editar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 28
 testRunner.And("El usuario confirma a edición del registro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 29
 testRunner.Then(string.Format("El sistema despliega en la grilla el registro modificado con la descripción {0}", descripcionEdit), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entonces ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("CP04_Eliminar Perfil")]
        [NUnit.Framework.TestCaseAttribute("TestGrupoAut1", "Informes Operativos", new string[] {
                "source:M02_Adm.Usuarios.xlsx:ELIMINAR.PERFIL"}, Category="source:M02_Adm.Usuarios.xlsx:ELIMINAR.PERFIL")]
        public virtual void CP04_EliminarPerfil(string descripcionSearch, string grupo, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CP04_Eliminar Perfil", exampleTags);
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.Given("El usuario ingresa a la opción de menú Listar perfil", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 37
 testRunner.And(string.Format("El usuario pulsa el botón Eliminar para el registro con descripción {0}", descripcionSearch), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 38
 testRunner.And(string.Format("El sistema despliega formulario con los campos Descripción y Grupo en modo sólo l" +
                        "ectura, y con la siguiente información: {0}, {1}", descripcionSearch, grupo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 39
 testRunner.When("El usuario pulsa el botón Eliminar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Cuando ");
#line 40
 testRunner.And("El usuario confirma la eliminación del registro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 41
 testRunner.Then(string.Format("El sistema no despliega en la grilla el registro con la descripción {0}", descripcionSearch), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entonces ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("CP05_Ver Detalle Perfil")]
        [NUnit.Framework.TestCaseAttribute("TestGrupoAut1", "Informes Operativos", new string[] {
                "source:M02_Adm.Usuarios.xlsx:VER.DETALLE.PERFIL"}, Category="source:M02_Adm.Usuarios.xlsx:VER.DETALLE.PERFIL")]
        public virtual void CP05_VerDetallePerfil(string descripcionSearch, string grupo, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CP05_Ver Detalle Perfil", exampleTags);
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
 testRunner.Given("El usuario ingresa a la opción de menú Listar Perfil", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 49
 testRunner.When(string.Format("El usuario pulsa el botón Detalle para el registro con descripción {0}", descripcionSearch), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Cuando ");
#line 50
 testRunner.Then(string.Format("El sistema despliega un modal con los campos Descripción y Grupo en modo sólo lec" +
                        "tura, y con la siguiente información: {0}, {1}", descripcionSearch, grupo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entonces ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

