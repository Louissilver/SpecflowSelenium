# SpecFlow + Selenium Automation Framework

Uma estrutura de automação em **C#** para testes de interface web, construída com **SpecFlow (BDD)** e **Selenium WebDriver**, usando **NUnit** como test runner.

---

## 🔧 Tecnologias e padrões utilizados

- **SpecFlow**: escrita de cenários em Gherkin e ligação com Step Definitions  
- **Selenium WebDriver**: interação com o navegador  
- **NUnit**: execução de testes, gestão de paralelismo e tags em hooks  
- **Page Object Model (POM)**: organização modular dos elementos da interface  
- **Hooks**: setup/teardown antes e após cada cenário (via `[BeforeScenario]` e `[AfterScenario]`)  
- **Relatórios**: screenshots no momento de falhas e logs em vários cenários

---

## 🚀 Como rodar o projeto

### Pré-requisitos
- Visual Studio ou Rider com suporte a .NET (versão compatível, ex: 6.0 ou superior)
- Pacotes NuGet: `SpecFlow`, `SpecFlow.NUnit`, `Selenium.WebDriver`, entre outros
- Drivers do navegador compatíveis (`chromedriver`, `msedgedriver`, etc.) adicionados ao projeto

### Passos
```bash
git clone https://github.com/Louissilver/SpecflowSelenium.git
cd SpecflowSelenium
dotnet restore
dotnet build
dotnet test
```

Ou execute os testes diretamente via Visual Studio Test Explorer conforme configurado.

---

## 📂 Estrutura do projeto

```
/
├── Features/                # Arquivos `.feature` com cenários em Gherkin
├── StepDefinitions/        # Métodos que mapeiam Given/When/Then
├── Pages/                  # Page Objects com locators e ações
├── Hooks/                  # Setup e cleanup de WebDriver e contexto de cenário
├── Drivers/                # Executáveis (chromedriver, geckodriver, etc.)
└── Configs/                # JSON ou config files (e.g. specflow.json)
```

---

## 📂 Recursos adicionais

- **Execução Paralela**: opção de paralelismo nativo com NUnit 3.x e atributos `[Parallelizable]`  
- **Relatórios**: geração de relatórios customizados (ex: ExtentReports) com screenshots em falhas  
- **Estrutura modular com teste limpo** (SOLID / Single Responsibility) alinhada com boas práticas

---

## 🛠️ Personalizações sugeridas

- Adicionar parametrização cross-browser (Chrome, Firefox etc.)
- Incluir integração com CI/CD (ex: GitHub Actions ou Azure DevOps)
- Gerar relatório HTML interativo ao final da execução
- Expandir uso de tags para organizar cenários por funcionalidades ou ambientes

---

## 📌 Como Contribuir

1. Fork o projeto  
2. Crie uma branch correspondente à sua feature ou bugfix  
3. Submeta um Pull Request com descrição clara e testes exemplares

---

## 🧠 Sobre

Baseado em um template interno de automação com SpecFlow + Selenium em C#, adaptado com estrutura modular, hooks e padrões de testes.

---
