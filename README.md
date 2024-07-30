# Controle de Cinema

## Descri��o do Projeto
Com a necessidade de gerenciar melhor as vendas de ingressos do Cinema de Lages, o Sr. Jo�o do Nascimento, propriet�rio do cinema, prop�s a cria��o de um sistema que auxilia no controle das vendas de ingressos para os clientes que desejam assistir filmes e desfrutar de pipoca nos finais de semana. A equipe do cinema busca otimizar o controle das v�rias salas e agilizar o processo de venda de ingressos.

## Requisitos Funcionais
1. **Gerenciamento de Salas e Filmes:**
   - Registro de informa��es sobre cada sala, incluindo capacidade e n�mero de assentos dispon�veis.
   - Registro de detalhes importantes sobre os filmes, como t�tulo, dura��o e g�nero.
   
2. **Registro de Lan�amentos:**
   - Possibilidade de registrar novos lan�amentos no acervo do cinema.
   
3. **Sess�es:**
   - Um filme pode ser exibido em diferentes salas e hor�rios, formando sess�es.
   - Cada sess�o ter� um n�mero m�ximo de ingressos � venda, conforme a capacidade da sala.
   
4. **Venda de Ingressos:**
   - Intermediada por funcion�rios do cinema.
   - Informa��es sobre o tipo de ingresso (inteiro ou meio ingresso).
   - Clientes s� podem comprar ingressos para sess�es ainda n�o encerradas.
   
5. **Visualiza��o de Sess�es:**
   - Funcion�rios podem visualizar as sess�es do dia agrupadas por filme, incluindo as em andamento e as que ainda v�o come�ar.
   
6. **M�dulo de Cadastro:**
   - Permite consulta, inclus�o, altera��o e remo��o de sess�es.
   - Exibe detalhes das sess�es, como poltronas dispon�veis e vendidas.

## Requisitos N�o Funcionais
1. **Ambiente:**
   - A aplica��o poder� ser acessada a partir de um navegador de internet (browser).
   
2. **Persist�ncia das Informa��es:**
   - Os dados devem ser salvos e recuperados em banco de dados utilizando ORM.
   
3. **Arquitetura:**
   - Utiliza��o do modelo de camadas.

4. **Qualidade:**
   - Cria��o de testes automatizados para os componentes da aplica��o.
   - Documenta��o do projeto, incluindo prot�tipos, diagramas e README.

## Estrutura do Projeto
- **Apresenta��o:** Interface gr�fica e intera��o com o usu�rio.
- **Dom�nio:** Regras de neg�cio e l�gica da aplica��o.
- **Infraestrutura:** Persist�ncia de dados e comunica��o com o banco de dados.