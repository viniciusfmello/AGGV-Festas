Proposta da solução:

Sprint I
Requisitos

A empresa Noiva & Cia é especializada na realização de cerimoniais para festas de casamento.

A empresa possui atualmente 8 espaços para realização de casamentos, que comportam quantidade diferente de pessoas: 4 espaços tem capacidade para 100 pessoas (espaços A-D), 2 espaços tem capacidade para 200 pessoas (espaços E-F), 1 espaço tem capacidade para 50 pessoas (espaço G) e o espaço restante tem capacidade para 400 pessoas (espaço H).
Para realização de um casamento, é necessária o agendamento antecipado de um espaço, de acordo com a quantidade de convidados esperados (deve ser selecionado o menor espaço que comporta os convidados).
Os casamentos são realizados somente às sextas-feiras e sábados. Somente é realizado um casamento por espaço, por dia.
A cerimôminia é realizada na data mais próxima disponível, de acordo com a quantidade de convidados (deve ser informada pelos noivos antes de solicitar a cerimônia).
O prazo mínimo para agendamento de cerimônias é 30 dias. Ao solicitar uma cerimônia, o sistema deve indicar a próxima data disponível e qual o melhor espaço para realização dos eventos.
Obs.: As datas devem corresponder à realidade.

Objetivos:

Modelo UML (agregação), classes básicas (e testes?), versão 1 do sistema.

Sprint II
Requisitos

Nesta etapa, será calculado o preço da festa de casamento.

Para evitar o armazenamento de valores diretamente no software, utilize um arquivo (ou um banco de dados) para armazenamento dos preços dos itens.

Aluguel do Espaço

O preço de aluguel do espaço para realização do casamento varia de acordo com a capacidade do local. O preço do espaço é ﬁxo, independentemente da quantidade de pessoas que participarão da festa.
A tabela abaixo contém o preço dos locais.

Espaço	Preço
A, B, C, D	$10.000,00
 
 

Espaço	Preço
E, F	$17.000,00
G	$8.000,00
H	$35.000,00

Tipo de Casamento

Além do aluguel do espaço, os noivos devem escolher, obrigatoriamente, o tipo de casamento a ser realizado. Os casamentos podem ser do tipo Premier, Luxo ou Standard. Os itens relacionados ao casamento devem ser somente de um tipo. Para cálculo dos valores, os preços dos itens devem ser multiplicados pela lotação máxima do espaço reservado.

Item	Premier	Luxo	Standard
Itens de mesas	$100,00	$75,00	$50,00
Decoração	$100,00	$75,00	$50,00
Bolo	$20,00	$15,00	$10,00
Música	$30,00	$25,00	$20,00

Todos os casamentos devem conter os 4 itens indicados na tabela acima. Todos os itens devem ser de uma mesma categoria.

Comidas

No casamento são oferecidos aos convidados exatamente 4 tipos de salgados, dentre a lista de opções disponíveis. Cada opção de salgado está relacionada ao tipo de casamento (premier, luxo ou standard). O preço base, no caso de comidas, deve ser multiplicado pela quantidade de pessoas presentes na festa.
A tabela abaixo contém os itens que podem ser escolhidos para a festa, o tipo (comum / especial) e o preço base correspondente.

Item	Tipo
Coxinha	Standard
 
Kibe	Standard
Empadinha	Standard
Pão de queijo	Standard Croquete carne seca	Luxo Barquetes legumes	Luxo Empadinha gourmet	Luxo Cestinha bacalhau	Luxo

 
Item	Tipo
Canapé	Premier
 
Tartine	Premier
Bruschetta	Premier Espetinho caprese	Premier
A tabela abaixo conté os preços bases dos salgados. O preço inclui salgados variados, dentro de um mesmo grupo.

Tipo	Preço
Standard	$40,00
Luxo	$48,00
Premier	$60,00

Bebidas

No casamento, a quantidade de bebidas deve ser gerenciada pelos noivos. A quantidade a ser adquirida deve ser feita de forma individual (escolha da quantidade de itens), de acordo com as preferências pessoais dos noivos.

A tabela abaixo contém os itens que podem ser escolhidos para a festa e seus respectivos preços unitários.

Item	Preço unitário
Água sem gás (1,5l)	$5,00
Suco (1L)	$7,00
Refrigerante (2l)	$8,00
Cerveja Comum (600ml)	$20,00
Cerveja Artesanal (600ml)	$30,00
Espumante Nacional (750ml)	$80,00
Espumante Importado (750ml)	$140,00

Cervejas artesanais e espumantes importados somente estão disponíveis para casamentos do tipo Luxo e Premier.

Cálculo do Preço da Festa
 
Após a seleção dos itens desejados pelos noivos, o sistema deve calcular o total a ser pago no casamento. A informação deve ser apresentada aos noivos.
Objetivos

Atualizar projeto UML, novas classes e testes, novas regras de negócio, herança. Acesso e persistência em arquivos. Versão 2 do sistema.
Sprint III
Nesta etapa, a empresa Noiva & Cia, decidiu expandir seus negócios, apostando em outros tipos de festas. A empresa passará, com a mudança, a se chamar Festa & Cia.

Requisitos

No novo modelo de negócios da empresa, a empresa terá como responsabilidade principal a locação dos espaços para as festas.
No entanto, poderá oferecer serviços, como itens de mesa e decoração, servir comidas e bebidas, conforme necessidade da festa.
No modelo atual, a empresa trabalhará com os seguintes tipos de festas:

Tipo	Serviços fornecidos
Casamento	Todos os serviços
 
Formatura	Exceto bolo
Festa de empresa	Exceto bolo, itens de mesa e decoração
 
Festa de aniversário	Todos os serviços (somente itens padrão standard)
Livre	Nenhum (Somente locação do espaço)

O sistema deverá ser alterado para atender aos novos requisitos e modalidades de festas disponíveis.

Objetivos

Nova regras do sistema. Aplicação dos padrões SOLID. Versão 3 do sistema.

Sprint IV
Nesta etapa, o sistema deverá persistir as informações. Também devem ser gerados os resumos dos itens solicitados nas festas. Por ﬁm, devem ser realizados os tratamentos de execeção para o projeto.

Requisitos

Resumo de preço da festa

O sistema, após seleção dos itens, deverá calcular e resumir os itens contratados. Devem ser gerado o preço ﬁnal da festa, com detalhes de todos os itens acordados e os preços por serviço contratado.
 
Persistência de informações

O sistema deverá permitir a persistência de informações cadastradas. Após ﬁnalizar a contratação de uma festa, esta deverá ser persistida (em arquivo ou banco de dados). Ao iniciar o sistema, este deverá voltar ao estado anterior, com todos as festas salvas.

Tratamento de Exceção

O software deverá ser alterado para inclusão de tratamento de exceção. Faça tratamento de exceção adequado para entradas do sistema (ex.: quantidade negativa de bebidas durante o planejamento das festas).

Objetivos

Persistência. Resumo da festa. Tratamentos de erros e exceções. Versão ﬁnal do sistema.
