# Retangulo

Documentação para uso da classe Retangulo.

## Teste

[**Possíveis declarações da classe Retangulo**](./Teste.md)

---

## Construtores

### Objeto de Cor Sólida

**Sintax:** Retangulo(float[] vertices, Vector3[] color, Matrix4? transformation).

**Descrição:** Inicializa um retângulo preenchido com uma cor sólida.

---

#### Parâmetro 01 - vertices

**Tipo:** Um array do tipo float - float[].

**Descrição:** Os vértices necessários para se desenhar o objeto.

**Sintax:** Esse parâmetro pode ser construído de duas maneiras diferentes:

- **Primeira Forma (O array possui Length = 12):** O array possui somente os vértices da figura final, ou seja, possui apenas os quatro vértices do retângulo;

- **Segunda Forma (O array possui Length = 18):** O array possui todos os vértices dos dois triângulos necessários para se desenhar o retângulo.

	**Sintax Geral:** O array é subdividido em grupos de 3 elementos, ou seja, um grupo de três elementos consecutivos corresponde as coordenadas X, Y e Z de um vértice.
	
	**Exemplo:** [0] = Coordenada X, [1] = Coordenada Y, [2] = Coordenada Z...

	**Alerta: Caso o array possua uma Length diferente de 12, e diferente de 18, uma exceção será lançada, interrompendo a execução do projeto!**

**Ordem:** Segue abaixo a ordem de vértices para esse parâmetro:

**Forma 1 (Length = 12):**

- **1° Vértice (index [0], [1], [2]):** Vértice Inferior Esquerdo;

- **2° Vértice (index [3], [4], [5]):** Vértice Inferior Direito;

- **3° Vértice (index [6], [7], [8]):** Vértice Superior Direito;

- **4° Vértice (index [9], [10], [11]):** Vértice Superior Esquerdo;


**Forma 2 (Length = 18):**

- **1° Triângulo (index [0]...[8]):**

	**1° Vértice (index [0], [1], [2]):** Vértice Inferior Esquerdo;

	**2° Vértice (index [3], [4], [5]):** Vértice Inferior Direito;

	**3° Vértice (index [6], [7], [8]):** Vértice Superior Direito.


- **2° Triângulo (index [9]...[17]):**

	**1° Vértice (index [9], [10], [11]):** Vértice Inferior Direito;

	**2° Vértice (index [12], [13], [14]):** Vértice Superior Direito;

	**3° Vértice (index [15], [16], [17]):** Vértice Superior Esquerdo.

---

#### Parâmetro 02 - color

**Tipo:** Um objeto do tipo Vector4.

**Descrição:** A cor de preenchimento do objeto.

**Sintax:** O código de cor adaptado para valores entre 0...1.

- **Vector4.X** = Canal Vermelho da Cor;

- **Vector4.Y** = Canal Verde da Cor;

- **Vector4.Z** = Canal Azul da Cor;

- **Vector4.W** = Canal Alpha da Cor.

---

#### Parâmetro 03 - transformation

**Tipo:** Um objeto do tipo Matrix4 ou null.

**Descrição:** A transformação que será aplicada ao objeto no momento de sua rendenização.

**Sintax:** Uma Matrix4 simples, podendo variar entre vários propósitos, como ajustar escala, posição ou rotação do objeto.

- **Alerta: Em caso deste parâmetro receber valor null nenhuma transformação será aplicada ao objeto, e esse será rendenizado conforme os vértices passados no parâmetro "vertices".**

---

### Objeto Colorido

**Sintax:** Retangulo(float[] vertices, Matrix4? transformation).

**Descrição:** Inicializa um retângulo preenchido com cores variadas.

---

#### Parâmetro 01 - vertices

**Tipo:** Um array do tipo float - float[].

**Descrição:** Os vértices necessários para se desenhar o objeto juntamente com seus respectivos códigos de cor.

**Sintax:** Esse parâmetro pode ser construído de duas maneiras diferentes:

- **Primeira Forma (O array possui Length = 24):** O array possui somente os vértices da figura final, ou seja, possui apenas os quatro vértices do retângulo;

- **Segunda Forma (O array possui Length = 36):** O array possui todos os vértices dos dois triângulos necessários para se desenhar o retângulo.

	**Sintax Geral:** O array é subdividido em grupos de 6 elementos. Um grupo de seis elementos consecutivos corresponde as coordenadas X, Y e Z e o código de cor de um vértice. 
	
	**Exemplo:** [0] = Coordenada X, [1] = Coordenada Y, [2] = Coordenada Z, [3] - Canal Vermelho da Cor, [4] - Canal Verde da Cor, [5] - Canal Azul da Cor...

	**Alerta: Caso o array possua uma Length diferente de 24, e diferente de 36, uma exceção será lançada, interrompendo a execução do projeto!**

**Ordem:** Segue abaixo a ordem de vértices para esse parâmetro:

**Forma 1 (Length = 24):**

- **1° Vértice (index [0]...[5]):** Vértice Inferior Esquerdo;
	- **[0], [1], [2]** - Coordenadas X, Y, Z;

	- **[3], [4], [5]** - Código de Cor (RGB).

- **2° Vértice (index [6]...[11]):** Vértice Inferior Direito;
	- **[6], [7], [8]** - Coordenadas X, Y, Z;

	- **[9], [10], [11]** - Código de Cor (RGB).

- **3° Vértice (index [12]...[17]):** Vértice Superior Direito;
	- **[12], [13], [14]** - Coordenadas X, Y, Z;

	- **[15], [16], [17]** - Código de Cor (RGB).

- **4° Vértice (index [18]...[23]):** Vértice Superior Esquerdo.
	- **[18], [19], [20]** - Coordenadas X, Y, Z;

	- **[21], [22], [23]** - Código de Cor (RGB).


**Forma 2 (Length = 36):**

- **1° Triângulo (index [0]...[17]):**

	**1° Vértice (index [0]...[5]):** Vértice Inferior Esquerdo;

	- **[0], [1], [2]** - Coordenadas X, Y, Z;

	- **[3], [4], [5]** - Código de Cor (RGB).

	**2° Vértice (index [6]...[11]):** Vértice Inferior Direito;

	- **[6], [7], [8]** - Coordenadas X, Y, Z;

	- **[9], [10], [11]** - Código de Cor (RGB).

	**3° Vértice (index [12]...[17]):** Vértice Superior Direito.

	- **[12], [13], [14]** - Coordenadas X, Y, Z;

	- **[15], [16], [17]** - Código de Cor (RGB).


- **2° Triângulo (index [18]...[35]):**

	**1° Vértice (index [18]...[22]):** Vértice Inferior Direito;

	- **[18], [19], [20]** - Coordenadas X, Y, Z;

	- **[21], [22], [23]** - Código de Cor (RGB).

	**2° Vértice (index [24]...[29]):** Vértice Superior Direito;

	- **[24], [25], [26]** - Coordenadas X, Y, Z;

	- **[27], [28], [29]** - Código de Cor (RGB).

	**3° Vértice (index [30]...[35]):** Vértice Superior Esquerdo.
	
	- **[30], [31], [32]** - Coordenadas X, Y, Z;

	- **[33], [34], [35]** - Código de Cor (RGB).

---

#### Parâmetro 02 - transformation

**Tipo:** Um objeto do tipo Matrix4 ou null.

**Descrição:** A transformação que será aplicada ao objeto no momento de sua rendenização.

**Sintax:** Uma Matrix4 simples, podendo variar entre vários propósitos, como ajustar escala, posição ou rotação do objeto.

- **Alerta: Em caso deste parâmetro receber valor null nenhuma transformação será aplicada ao objeto, e esse será rendenizado conforme os vértices passados no parâmetro "vertices".**

---


### Objeto texturizado

**Sintax:** public Retangulo(float[] vertices, string texturePath, Matrix4? transformation).

**Descrição:** Inicializa um retângulo preenchido com textura.

---

#### Parâmetro 01 - vertices

**Tipo:** Um array do tipo float - float[].

**Descrição:** Os vértices necessários para se desenhar o objeto juntamente com suas respectivas coordenadas de textura.

**Sintax:** Esse parâmetro pode ser construído de duas maneiras diferentes:

- **Primeira Forma (O array possui Length = 20):** O array possui somente os vértices da figura final, ou seja, possui apenas os quatro vértices do retângulo;

- **Segunda Forma (O array possui Length = 30):** O array possui todos os vértices dos dois triângulos necessários para se desenhar o retângulo.

	**Sintax Geral:** O array é subdividido em grupos de 5 elementos. Um grupo de cinco elementos consecutivos corresponde as coordenadas X, Y e Z e a coordenada de textura de um vértice.
	
	**Exemplo:** [0] = Coordenada X, [1] = Coordenada Y, [2] = Coordenada Z, [3] - Coordenada X de Textura, [4] - Coordenada Y de Textura...

	**Alerta: Caso o array possua uma Length diferente de 20, e diferente de 30, uma exceção será lançada, interrompendo a execução do projeto!**

**Ordem:** Segue abaixo a ordem de vértices para esse parâmetro:

**Forma 1 (Length = 20):**

- **1° Vértice (index [0]...[4]):** Vértice Inferior Esquerdo;
	- **[0], [1], [2]** - Coordenadas X, Y, Z;

	- **[3], [4]** - Coordenada X, Y de Textura.

- **2° Vértice (index [5]...[9]):** Vértice Inferior Direito;
	- **[5], [6], [7]** - Coordenadas X, Y, Z;

	- **[8], [9]** - Coordenada X, Y de Textura.

- **3° Vértice (index [10]...[14]):** Vértice Superior Direito;
	- **[10], [11], [12]** - Coordenadas X, Y, Z;

	- **[13], [14]** - Coordenada X, Y de Textura.

- **4° Vértice (index [15]...[19]):** Vértice Superior Esquerdo;
	- **[15], [16], [17]** - Coordenadas X, Y, Z;

	- **[18], [19]** - Coordenada X, Y de Textura.


**Forma 2 (Length = 30):**

- **1° Triângulo (index [0]...[14]):**

	**1° Vértice (index [0]...[4]):** Vértice Inferior Esquerdo;

	- **[0], [1], [2]** - Coordenadas X, Y, Z;

	- **[3], [4]** - Coordenada X, Y de Textura.

	**2° Vértice (index [5]...[9]):** Vértice Inferior Direito;

	- **[5], [6], [7]** - Coordenadas X, Y, Z;

	- **[8], [9]** - Coordenada X, Y de Textura.

	**3° Vértice (index [10]...[14]):** Vértice Superior Direito.

	- **[10], [11], [12]** - Coordenadas X, Y, Z;

	- **[13], [14]** - Coordenada X, Y de Textura.


- **2° Triângulo (index [15]...[29]):**

	**1° Vértice (index [15]...[19]):** Vértice Inferior Direito;

	- **[15], [16], [17]** - Coordenadas X, Y, Z;

	- **[18], [19]** - Coordenada X, Y de Textura.

	**2° Vértice (index [20]...[24]):** Vértice Superior Direito;

	- **[20], [21], [22]** - Coordenadas X, Y, Z;

	- **[23], [24]** - Coordenada X, Y de Textura.

	**3° Vértice (index [25]...[29]):** Vértice Superior Esquerdo.
	
	- **[25], [26], [27]** - Coordenadas X, Y, Z;

	- **[28], [29]** - Coordenada X, Y de Textura.

---

#### Parâmetro 02 - texturePath

**Tipo:** String.

**Descrição:** O caminho para o arquivo de textura a ser utilizado no preenchimento do objeto.

**Sintax:** Caminho relativo ao arquivo de textura.

---

#### Parâmetro 03 - transformation

**Tipo:** Um objeto do tipo Matrix4 ou null.

**Descrição:** A transformação que será aplicada ao objeto no momento de sua rendenização.

**Sintax:** Uma Matrix4 simples, podendo variar entre vários propósitos, como ajustar escala, posição ou rotação do objeto.

- **Alerta: Em caso deste parâmetro receber valor null nenhuma transformação será aplicada ao objeto, e esse será rendenizado conforme os vértices passados no parâmetro "vertices".**

---

## Métodos de Rendenização Opengl

### InitializeOpenglObjects()

**Parâmetros:** Não Possui.

**Retorno:** Void;

**Descrição:** Método responsável por inicializar os objetos opengl de acordo com o construtor utilizado.

---

### InitializeSolidColorVertexArray()

**Parâmetros:** Não Possui.

**Retorno:** Void;

**Descrição:** Método responsável por configurar os objetos opengl e os shaders de acordo com as configurações de um objeto de cor sólida.

---

### InitializeColorVertexArray()

**Parâmetros:** Não Possui.

**Retorno:** Void;

**Descrição:** Método responsável por configurar os objetos opengl e os shaders de acordo com as configurações de um objeto de várias cores.

---

### InitializeTextureVertexArray()

**Parâmetros:** Não Possui.

**Retorno:** Void;

**Descrição:** Método responsável por configurar os objetos opengl e os shaders de acordo com as configurações de um objeto texturizado.

---

### DrawObject()

**Parâmetros:** Não Possui.

**Retorno:** Void;

**Descrição:** Método responsável por rendenizar o objeto na tela de acordo com as configurações selecionadas.

---

## Métodos Responsaveis pela Criação Automática de Vértices

### CreateSolidColorVertices()

**Parâmetros:** 

- **Vector3** centerPosition;
	
	A coordenada X, Y, Z do ponto central do objeto.

- **float** width;

	A largura do objeto.

- **float** height;

	A altura do objeto.

- **bool** verticesEconomized;

	Indica se o objeto deve utiizar a tecnologia de vétices reduzidos;

	- **True:** O array retornado irá contêr apenas as coordenadas dos 4 vértices primários do retângulo;

	- **False:** O array retornado irá contêr as coordenadas de todos os vértices dos dois triângulos necessários para a construção do retângulo.

**Retorno:** float[];

**Descrição:** Método responsável por criar as coordenadas dos vértices do objeto.

#### Sobrecargas
	
- CreateSolidColorVertices().
		
	**Parâmetros:**

	- **Vector3[]** vertices;

		Os Vértices do objeto condensados em um array Vector3. Cada posição do array corresponde a um vértice e as propriedades X, Y,e Z do Vector3 correspondem respectivamente as coordenadas X, Y e Z do vértice.

	**Retorno:** float[];

	**Descrição:** Transforma vértices tipados em Vector3 para vértices legíveis ao opengl em tipo float.

---

### CreateColorVertices()

**Parâmetros:**

- **Vector3** centerPosition;
	
	A coordenada X, Y, Z do ponto central do objeto.

- **Vector3[]** color;

	Os códigos de cor dos vértices do objeto. Pode ser construído de duas maneiras: a primeira lista as cores para os quatro vértices principais do retângulo, e a segunda opção lista as cores de cada um dos vértices dos dois triângulos constituintes do retângulo.

	**1° Opção (Length = 4):**
		
	- **Index [0]:** Código de cor do vértice superior esquerdo;
		
	- **Index [1]:** Código de cor do vértice superior direito;
		
	- **Index [2]:** Código de cor do vértice inferior esquerdo;
		
	- **Index [3]:** Código de cor do vértice inferior direito;

	**2° Opção (Length = 6):**

	- **1° Triângulo (index [0]...[2]):**

		- **Index [0]:** Código de cor do vértice superior esquerdo;

		- **Index [1]:** Código de cor do vértice superior direito;

		- **Index [2]:** Código de cor do vértice inferior esquerdo.

	- **2° Triângulo (index [3]...[5]):**

		- **Index [3]:** Código de cor do vértice superior direito;

		- **Index [4]:** Código de cor do vértice inferior esquerdo;

		- **Index [5]:** Código de cor do vértice inferior direito.

	**Atenção: As propriedades X, Y e Z, do objeto Vector3, correspondem, respectivamente, aos canais Vermelho, Verde e Azul da cor (RGB).**

	**Caso a Length do objeto color seja diferente de 4, e diferente de 6, uma exceção será lançada, interrompendo a execução do projeto!**

- **float** width;

	A largura do objeto.

- **float** height;

	A altura do objeto.

- **bool** verticesEconomized;

	Indica se o objeto deve utiizar a tecnologia de vétices reduzidos;

	- **True:** O array retornado irá contêr apenas as coordenadas dos 4 vértices primários do retângulo;

	- **False:** O array retornado irá contêr as coordenadas de todos os vértices dos dois triângulos necessários para a construção do retângulo.

**Retorno:** float[];

**Descrição:** Método responsável por criar as coordenadas dos vértices do objeto, já mapeadas com suas respectivas cores.

---

### ImplementColorAtributtes()

**Parâmetros:**

- **float[]** vertices;

	Os vértices simples do objeto, sem adição de coordenadas de textura ou códigos de cor. Pode ser apresentado de duas maneiras; na primeira contém apenas as coordenadas dos quatro vértices principais do retângulo, e na segunda, contém todas as coordenadas dos vértices dos dois triângulos necessários para a construção do retângulo.

	**Atenção: Caso a Length deste parâmetro seja diferente de 12, e diferente de 18, uma exceção será lançada, interrompendo a execução do projeto!**

- **Vector3[]** colors;

	Os códigos de cor para cada vértice do objeto. Pode ser construído de duas formas; na primeira o array contém os códigos de cor apenas para os quatro vértices primários do retângulo. Na segunda, o objeto contém os códigos de cor para todos os vértice dos dois triângulos necessários para se construir o retângulo.

	**Opção 1 (Length = 4):**

	- **Index [0]:** Código de cor do vértice superior esquerdo;

	- **Index [1]:** Código de cor do vértice superior direito;

	- **Index [2]:** Código de cor do vértice inferior esquerdo;

	- **Index [3]:** Código de cor do vértice inferior direito;

	**Opção 2 (Length = 6):**

	- **1° Triângulo (index [0]...[2]):**

		- **Index [0]:** Código de cor do vértice superior esquerdo;

		- **Index [1]:** Código de cor do vértice superior direito;

		- **Index [2]:** Código de cor do vértice inferior esquerdo.

	- **2° Triângulo (index [3]...[5]):**

		- **Index [3]:** Código de cor do vértice superior direito;

		- **Index [4]:** Código de cor do vértice inferior esquerdo;

		- **Index [5]:** Código de cor do vértice inferior direito.

	**Lembrete: As propriedades X, Y e Z, do objeto Vector3, correspondem, respectivamente, aos canais Vermelho, Verde e Azul da cor (RGB).**

	**Atenção: Caso a Length deste parâmetro seja diferente de 4, e diferente de 6, uma exceção será lançada, interrompendo a execução do projeto!**

**Retorno:** float[];

**Descrição:** Transforma vértices normais em vértices com código de cor, partindo da adição dos códigos de cor passados em "colors" as coordenadas de vértices passadas em "vertices".

---

### CreateTextureVertices()

**Parâmetros:**

- **Vector3** centerPosition;

	A coordenada X, Y, Z do ponto central do objeto.

- **float** width;

	O largura do objeto.

- **float** height;

	A altura do objeto.

- **bool** verticesEconomized;

	Indica se o objeto deve utiizar a tecnologia de vértices reduzidos;

	- **True:** O array retornado irá contêr apenas as coordenadas dos 4 vértices primários do retângulo;

	- **False:** O array retornado irá contêr as coordenadas de todos os vértices dos dois triângulos necessários para a construção do retângulo.

**Retorno:** float[];

**Descrição:** Cria um array de coordenadas de vértices a partir de uma posição central e o comprimento do lado do retângulo.

---

### ImplementTextureVertices()

**Parâmetros:**

- **float[]** vertices;

	Os vértices simples do objeto, sem adição de coordenadas de textura ou códigos de cor. Pode ser apresentado de duas maneiras; na primeira contém apenas as coordenadas dos quatro vértices principais do retângulo, e, na segunda, contém todas as coordenadas dos vértices dos dois triângulos necessários para a construção do retângulo.

	**Atenção: Caso a Length deste parâmetro seja diferente de 12, e diferente de 18, uma exceção será lançada, interrompendo a execução do projeto!**

- **Vector2[]?** textureCoords;

	As coordenadas de textura a serem aplicadas aos vértices; Subdivide-se em 3 opções: valor nulo, as coordenadas de textura dos quatro vértices principais do retângulo e as coordenadas de textura de todos os vértices de cada um dos dois triângulos necessários para a formação do retângulo.

	**Opção 1 (valor nulo):**

	- O algoritmo irá criar as coordenadas de textura automaticamente. Certifique-se de mantêr a ordem de vértices padrão; inferior esquerdo, inferior direito, superior direito e superior esquerdo, ao fazer uso desse recurso, tendo por finalidade evitar possíveis distorções no mapeamento de textura.

	**Opção 2 (Length = 4):**

	- **Index [0]:** Coordenada de textura (X, Y) do vértice superior esquerdo;

	- **Index [1]:** Coordenada de textura (X, Y) do vértice superior direito;

	- **Index [2]:** Coordenada de textura (X, Y) do vértice inferior esquerdo;

	- **Index [3]:** Coordenada de textura (X, Y) do vértice inferior direito;

	**Opção 3 (Length = 6):**

	- **1° Triângulo (index [0]...[2]):**

		- **Index [0]:** Vértice superior esquerdo;

		- **Index [1]:** Vértice superior direito;

		- **Index [2]:** Vértice inferior esquerdo.

	- **2° Triângulo (index [3]...[5]):**

		- **Index [3]:** Vértice superior direito;

		- **Index [4]:** Vértice inferior esquerdo;

		- **Index [5]:** Vértice inferior direito.

**Retorno:** float[];

**Descrição:** Transforma vértices normais em vértices com coordenadas de textura, partindo da adição das coordenadas de textura, passadas em "textureCoords", as coordenadas de vértices, passadas em "vertices".

---

### CreateIndices()

**Parâmetros:**

- **bool** verticesEconomized;

	Indica se os índices devem corresponder a coordenadas de vértices otimizadas ou sem otimização.

**Retorno:** uint[];

**Descrição:** Constrói automaticamente os índices de mapeamento dos vértices de triângulos.

**Atenção: O método constrói índices para vértices construídos seguindo a ordem padrão; inferior esquerdo, inferior direito, superior direito e superior esquerdo. Caso os vértices não respeitem essa ordem, distorções podem ocorrer ao objeto!**