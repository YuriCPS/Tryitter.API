using System;
using TechTalk.SpecFlow;

namespace Tryitter.TESTS.StepDefinitions
{
    [Binding]
    public class AccountControllerStepDefinitions
    {
        [Given(@"que um novo usuário está se registrando com os seguintes dados")]
        public void GivenQueUmNovoUsuarioEstaSeRegistrandoComOsSeguintesDados(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"deve retornar o http status code (.*)")]
        public void ThenDeveRetornarOHttpStatusCode(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"que já existe um usuário com o email informado")]
        public void GivenQueJaExisteUmUsuarioComOEmailInformado()
        {
            throw new PendingStepException();
        }

        [Given(@"que já existe um usuário com o userName informado")]
        public void GivenQueJaExisteUmUsuarioComOUserNameInformado()
        {
            throw new PendingStepException();
        }

        [Given(@"que um usuário está logando com os seguintes dados")]
        public void GivenQueUmUsuarioEstaLogandoComOsSeguintesDados(Table table)
        {
            throw new PendingStepException();
        }

        [Given(@"que não existe um usuário com o userName informado")]
        public void GivenQueNaoExisteUmUsuarioComOUserNameInformado()
        {
            throw new PendingStepException();
        }
    }
}
