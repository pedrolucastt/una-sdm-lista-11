# 🏦 GlobalBankApi

Projeto desenvolvido para a disciplina de Sistemas Distribuídos e Mobile.

## 🚀 Tecnologias
- .NET Web API
- Entity Framework InMemory
- Swagger

## 📦 Funcionalidades

### Contas
- Criar conta
- Listar contas

### Transações
- Depósito
- Saque
- Validação de saldo
- Extrato por conta

### Dashboard
- Patrimônio total
- Total de transações

## ⚠️ Regra importante
- Não permite saldo inicial negativo
- Saque não pode ultrapassar saldo
- Transações acima de 10.000 geram alerta no console

## 🧠 Pergunta teórica

Como o banco é em memória (InMemory), ao reiniciar o servidor:
- Todos os dados são perdidos
- Em sistemas distribuídos, cada instância teria dados diferentes
- Isso pode causar inconsistência de saldo entre servidores

## 📸 Evidências


