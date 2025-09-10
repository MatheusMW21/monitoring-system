# Monitoring System

Este repositório reúne experimentos pessoais relacionados a **sistemas de monitoramento**.  
O objetivo é explorar conceitos como **coleta de métricas, automação, alertas e dashboards em tempo real**, aplicando tecnologias modernas de backend, mensageria e cloud.

> Este é um projeto de estudo/prototipação, não uma solução pronta para produção.

---

## Tecnologias Utilizadas

- **Backend:** C# (.NET 9) + ASP.NET Core Web API  
- **Background Services:** .NET Worker Services para processamento contínuo  
- **Banco de Dados:** Azure SQL ou Cosmos DB (armazenamento de métricas e histórico)  
- **Mensageria/Filas:** Azure Service Bus (processamento assíncrono e alertas)  
- **Dashboard em Tempo Real:** SignalR  
- **Notificações:** Azure Logic Apps, SendGrid (e-mail)  
- **Containerização/Cloud:** Docker  

---

## Funcionalidades Exploradas

- Coleta e armazenamento de métricas do sistema (CPU, memória, logs).  
- Avaliação automática de **thresholds** configurados.  
- Registro e histórico de alertas em banco de dados.  
- Envio de **notificações em tempo real** (e-mail, SMS, chat).  
- Atualização dinâmica de dashboards com SignalR.  
- Estruturação modular para facilitar manutenção e evolução.  

---

## Fluxo de Processamento

1. Métricas são recebidas do banco ou de mensagens via **Azure Service Bus**.  
2. O sistema avalia **thresholds pré-configurados** (ex.: CPU > 80%, Memória > 90%).  
3. Caso ultrapasse os limites:  
   - Cria registro na tabela `Alerts`.  
   - Dispara notificação (e-mail, SMS ou chat).  
   - Atualiza o **dashboard em tempo real** via SignalR.  

---

## Como Executar (Exemplo)

1. Clone o repositório:
   ```bash
   git clone https://github.com/MatheusMW21/monitoring-system.git
   cd monitoring-system

    Configure as variáveis de ambiente (connection strings, Azure Service Bus, etc).

    Execute a API:

    dotnet run --project MonitoringSystem.Api


   (Opcional) Rode os serviços em containers:

    docker-compose up -d

Licença

MIT — Sinta-se livre para usar, modificar e compartilhar.


---

Essa versão já passa uma imagem de **projeto real de monitoramento**, mesmo sendo estudo. 
