# Controle de Cinema

## Descrição do Projeto
Com a necessidade de gerenciar melhor as vendas de ingressos do Cinema de Lages, o Sr. João do Nascimento, proprietário do cinema, propôs a criação de um sistema que auxilia no controle das vendas de ingressos para os clientes que desejam assistir filmes e desfrutar de pipoca nos finais de semana. A equipe do cinema busca otimizar o controle das várias salas e agilizar o processo de venda de ingressos.

## Requisitos Funcionais
1. **Gerenciamento de Salas e Filmes:**
   - Registro de informações sobre cada sala, incluindo capacidade e número de assentos disponíveis.
   - Registro de detalhes importantes sobre os filmes, como título, duração e gênero.
   
2. **Registro de Lançamentos:**
   - Possibilidade de registrar novos lançamentos no acervo do cinema.
   
3. **Sessões:**
   - Um filme pode ser exibido em diferentes salas e horários, formando sessões.
   - Cada sessão terá um número máximo de ingressos à venda, conforme a capacidade da sala.
   
4. **Venda de Ingressos:**
   - Intermediada por funcionários do cinema.
   - Informações sobre o tipo de ingresso (inteiro ou meio ingresso).
   - Clientes só podem comprar ingressos para sessões ainda não encerradas.
   
5. **Visualização de Sessões:**
   - Funcionários podem visualizar as sessões do dia agrupadas por filme, incluindo as em andamento e as que ainda vão começar.
   
6. **Módulo de Cadastro:**
   - Permite consulta, inclusão, alteração e remoção de sessões.
   - Exibe detalhes das sessões, como poltronas disponíveis e vendidas.

## Requisitos Não Funcionais
1. **Ambiente:**
   - A aplicação poderá ser acessada a partir de um navegador de internet (browser).
   
2. **Persistência das Informações:**
   - Os dados devem ser salvos e recuperados em banco de dados utilizando ORM.
   
3. **Arquitetura:**
   - Utilização do modelo de camadas.

4. **Qualidade:**
   - Criação de testes automatizados para os componentes da aplicação.
   - Documentação do projeto, incluindo protótipos, diagramas e README.

## Estrutura do Projeto
- **Apresentação:** Interface gráfica e interação com o usuário.
- **Domínio:** Regras de negócio e lógica da aplicação.
- **Infraestrutura:** Persistência de dados e comunicação com o banco de dados.