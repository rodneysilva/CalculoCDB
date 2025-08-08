# 💰 Simulador de Investimento em CDB [B3 Test]

Este projeto simula o rendimento de um investimento em CDB, considerando CDI, TB e imposto de renda regressivo. A aplicação segue os princípios de **DDD**, **SOLID** e **Clean Architecture**, utilizando **.NET 9** no backend e **Angular** no frontend.

---

## 🧱 Estrutura do Projeto

```
CalculoCDB /
├── src /
│   ├── Application /          	# Camada com as regras de negócio
│   ├── Domain /    			# Camada do negócio
│   ├── Web /					# Pasta com a camada da API e a pasta do Frontend
│		 └── ClientApp/			# Solução Angular
├── tests /
│   └── Application.UnitTests / # Testes unitários da aplicação
│   └── Domain.UnitTests /      # Testes unitários do domínio
│   └── Web.UnitTests /         # Testes unitários da API
```

---

## 🚀 Como Executar

### 🔧 Backend (.NET 9)

1. Navegue até a pasta da API/Frontend:
    ```
    cd src/Web
    ```

2. Restaure os pacotes, build e execute:
    ```
    dotnet restore
    dotnet build
    dotnet run
    ```
3. A Aplicação estará disponível em `http://localhost:5001` ou `https://localhost:44447`.

4. A API estará disponível em `http://localhost:5001/api` ou `https://localhost:44447/api`.

---

## 📈 Fórmula de Cálculo

```
Valor Final = Valor Inicial × [1 + (CDI × TB)] ^ Prazo

Imposto de Renda:
- Até 6 meses: 22,5%
- Até 12 meses: 20%
- Até 24 meses: 17,5%
- Acima de 24 meses: 15%
```

---

## 🧪 Testes

### Execução dos testes unitários
- Na pasta raiz do projeto executar o comando:
```
dotnet test
  ```
- Os testes serão realizados nas camadas `Application`, `Domain` e `Web`.
---

## 📚 Requisitos

- [.NET SDK 9](https://dotnet.microsoft.com/en-us/download)
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)