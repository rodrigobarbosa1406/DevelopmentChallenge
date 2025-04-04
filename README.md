# **Refatoração do código**

As seguintes adequações foram realizadas para atender aos requisitos:
<br><br><br>

## **Classe "FormaGeometrica"**
A classe "FormaGeometrica" _(renomeada para "GeometricShape")_ passou a ser uma classe abstrata com as propriedades "Area" e "Perimeter" e com os métodos "CalculateArea()" e "CalculatePerimeter()".
<br><br>

## **Representação das formas geométricas**
Cada forma geométrica passou a ser representada por uma classe que herda de "GeometricShape" contendo suas propriedades específicas e a implementação personalizada dos métodos "CalculateArea()" e "CalculatePerimeter()". Sendo assim, se houver a necessidade de implementar novas formas geométricas deve-se criar uma classe que a represente com suas respectivas propriedades e implementações dos métodos "CalculateArea()" e "CalculatePerimeter()". As classes criadas foram:

- [ ] Circle;
- [ ] EquilateralTriangle;
- [ ] Rectangle;
- [ ] Square;
- [ ] Trapeze.
<br><br>

## **Linguagens**
Para listar as linguagens suportadas pela aplicação foi criado o enumerador "Language" com as opções existentes _(CASTELLANO = 1; ENGLISH = 2)_ e com o acréscimo da nova linguagem ITALIAN (3). Para flexibilizar a criação de novas linguagens foi adicionado ao projeto o arquivo "languages.json" que tem uma estrutura que permite armazenar textos traduzidos de modo que possam ser recuperados pela aplicação através de parâmetros. Sendo assim, se houver a necessidade de adicionar novas linguagens deve-se proceder da seguinte forma:
- [ ] Adicionar um novo item ao enumerador "Language";
- [ ] Adicionar um novo nó ao arquivo "languages.json" com os textos traduzidos para a referida linguagem;
- [ ] Passar a linguagem como parâmetro na chamada do método "PrintReport" usando a opção correspondente do enumerador;
<br><br>

## **Método Imprimir(List<FormaGeometrica> formas, int idioma)**
O método "Imprimir(List<FormaGeometrica> formas, int idioma)" foi retirado da classe "FormaGeometrica" _(renomeada para "GeometricShape")_ e dividido em três partes para isolar responsabilidades:
- [ ] A classe estática "LanguagesHandler" que possui o método "GetSelectedLanguage(Language language)" que abre o arquivo "languages.json", obtém e retorna o nó correspondente a linguagem enviada por parâmetro e o método "GetCultureInfo(JToken selectedLanguage)" que obtém o nome da cultura referente a linguagem utilizada e retorna um objeto CultureInfo instanciado para a referida cultura;
- [ ] A classe estática "TextGetter" que possui métodos para capturar diferentes partes de texto do nó obtido de "languages.json" obtido através do método "GetSelectedLanguage(Language language)";
- [ ] A classe estática "Print" que possui o método "PrintReport(List<GeometricShape> geometricShapes, Language language)" para gerar o relatório na linguagem selecionada.
<br><br>

## **Testes Unitários**
O projeto de testes foi atualizado:
- [ ] Novo método SummaryTestEmptyListFormsInItalian();
- [ ] Novo método SummaryTestListWithMoreSquaresInItalian();
- [ ] Novo método TestSummaryListWithMoreTypesInItalian();
- [ ] Os métodos existentes TestSummaryListWithMoreTypesInCastellano() e TestSummaryListWithMoreTypes() foram atualizados com a inclusão das formas geométricas "Rectangle" e "Trapeze" na lista de formas.
