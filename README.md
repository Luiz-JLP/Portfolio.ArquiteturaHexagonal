# Arquitetura Hexagonal

Este projeto é uma demonstração de conhecimento na construção de uma API simples utilizando a **Arquitetura Hexagonal**.

## Estrutura do Projeto

O projeto foi dividido em duas partes principais:

### 1. Core

- **Domain**: Contém as entidades, enumeradores, requests, responses, além das Portas e Contratos de Serviço.
- **Application**: Implementa os contratos de serviços e contém as regras de negócio.

### 2. Adapters

Na pasta `Adapters`, encontram-se os adaptadores primários e secundários:

- **Banco de Dados**: Foi criado um adaptador de banco de dados em memória para facilitar a utilização e testes.
- **Envio de E-mail**: Adaptador que simula o envio de e-mail, registrando o envio no prompt de comando ao invés de realmente enviar uma mensagem.
- **WebAPI**: Projeto `WebAPI` em **.NET Core**, utilizando documentação **OpenAPI/Swagger**, com dois controladores:
  - **Pessoa Física**: Controle para gerenciar entidades de Pessoa Física.
  - **Endereços**: Controle para gerenciar endereços.

## Testes

Todas as partes principais do projeto estão cobertas por testes unitários, com cobertura superior a 99%. Esses testes podem ser encontrados na pasta `tests`.

---

Este é um projeto criado com o intuito de demonstrar a aplicação prática da Arquitetura Hexagonal, utilizando ferramentas modernas e boas práticas de desenvolvimento.
