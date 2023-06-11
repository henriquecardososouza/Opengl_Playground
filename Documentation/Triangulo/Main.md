# Triangulo

Documentação para uso da classe Triangulo.

## Teste

[**Possíveis declarações da classe Triangulo**](./Teste.md)

---

## Construtores

### Objeto de Cor Sólida

**Sintax:** Triangulo(float[] vertices, Vector3[] color, Matrix4? transformation).

**Descrição:** Inicializa um triângulo preenchido com uma cor sólida.

---

#### Parâmetro 01 - vertices

**Tipo:** Um array do tipo float - float[].

**Descrição:** Os vértices necessários para se desenhar o objeto.

**Sintax:** Esse parâmetro pode ser construído apenas de uma maneira, tendo Length = 9;

- **Sintax Geral:** O array é subdividido em grupos de 3 elementos, ou seja, um grupo de três elementos consecutivos corresponde as coordenadas X, Y e Z de um vértice. **Exemplo:** [0] = Coordenada X, [1] = Coordenada Y, [2] = Coordenada Z...

**Alerta: Caso o array possua uma Length diferente de 9 uma exceção será lançada, interrompendo a execução do projeto!**

**Ordem:** Segue abaixo a ordem de vértices para esse parâmetro:

- **1° Vértice (index [0], [1], [2]):** Vértice Inferior Esquerdo;

- **2° Vértice (index [3], [4], [5]):** Vértice Superior;

- **3° Vértice (index [6], [7], [8]):** Vértice Inferior Direito;

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

- **Alerta: Em caso deste parâmetro receber valor null, nenhuma transformação será aplicada ao objeto, e esse será rendenizado conforme os vértices passados no parâmetro "vertices".**

---

### Objeto Colorido

**Sintax:** Triangulo(float[] vertices, Matrix4? transformation).

**Descrição:** Inicializa um triângulo preenchido com cores variadas.

---

#### Parâmetro 01 - vertices

**Tipo:** Um array do tipo float - float[].

**Descrição:** Os vértices necessários para se desenhar o objeto juntamente com seus respectivos códigos de cor.

**Sintax:** Esse parâmetro pode ser construído apenas de uma maneira, tendo Length = 18;

- **Sintax Geral:** O array é subdividido em grupos de 6 elementos. Um grupo de seis elementos consecutivos corresponde as coordenadas X, Y e Z e o código de cor de um vértice. 

	**Exemplo:** [0] = Coordenada X, [1] = Coordenada Y, [2] = Coordenada Z, [3] - Canal Vermelho da Cor, [4] - Canal Verde da Cor, [5] - Canal Azul da Cor...

**Alerta: Caso o array possua uma Length diferente 18, uma exceção será lançada, interrompendo a execução do projeto!**

**Ordem:** Segue abaixo a ordem de vértices para esse parâmetro:

- **1° Vértice (index [0]...[5]):** Vértice Inferior Esquerdo;
	- **[0], [1], [2]** - Coordenadas X, Y, Z;

	- **[3], [4], [5]** - Código de Cor (RGB).

- **2° Vértice (index [6]...[11]):** Vértice Superior;
	- **[6], [7], [8]** - Coordenadas X, Y, Z;

	- **[9], [10], [11]** - Código de Cor (RGB).

- **3° Vértice (index [12]...[17]):** Vértice Inferior Direito;
	- **[12], [13], [14]** - Coordenadas X, Y, Z;

	- **[15], [16], [17]** - Código de Cor (RGB).

---

#### Parâmetro 02 - transformation

**Tipo:** Um objeto do tipo Matrix4 ou null.

**Descrição:** A transformação que será aplicada ao objeto no momento de sua rendenização.

**Sintax:** Uma Matrix4 simples, podendo variar entre vários propósitos, como ajustar escala, posição ou rotação do objeto.

- **Alerta: Em caso deste parâmetro receber valor null, nenhuma transformação será aplicada ao objeto, e esse será rendenizado conforme os vértices passados no parâmetro "vertices".**

---


### Objeto texturizado

**Sintax:** public Triangulo(float[] vertices, string texturePath, Matrix4? transformation).

**Descrição:** Inicializa um triângulo preenchido com textura.

---

#### Parâmetro 01 - vertices

**Tipo:** Um array do tipo float - float[].

**Descrição:** Os vértices necessários para se desenhar o objeto juntamente com suas respectivas coordenadas de textura.

**Sintax:** Esse parâmetro pode ser construído apenas de uma maneira, tendo Length = 15;

- **Sintax Geral:** O array é subdividido em grupos de 5 elementos. Um grupo de cinco elementos consecutivos corresponde as coordenadas X, Y e Z e a coordenada de textura de um vértice.

	**Exemplo:** [0] = Coordenada X, [1] = Coordenada Y, [2] = Coordenada Z, [3] - Coordenada X de Textura, [4] - Coordenada Y de Textura...

**Alerta: Caso o array possua uma Length diferente de 15, uma exceção será lançada, interrompendo a execução do projeto!**

**Ordem:** Segue abaixo a ordem de vértices para esse parâmetro:

- **1° Vértice (index [0]...[4]):** Vértice Inferior Esquerdo;
	- **[0], [1], [2]** - Coordenadas X, Y, Z;

	- **[3], [4]** - Coordenada X, Y de Textura.

- **2° Vértice (index [5]...[9]):** Vértice Inferior;
	- **[5], [6], [7]** - Coordenadas X, Y, Z;

	- **[8], [9]** - Coordenada X, Y de Textura.

- **3° Vértice (index [10]...[14]):** Vértice Inferior Direito;
	- **[10], [11], [12]** - Coordenadas X, Y, Z;

	- **[13], [14]** - Coordenada X, Y de Textura.

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

- **Alerta: Em caso deste parâmetro receber valor null, nenhuma transformação será aplicada ao objeto, e esse será rendenizado conforme os vértices passados no parâmetro "vertices".**

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

- **float** sideLength;

	O comprimento do lado do objeto.

**Retorno:** float[];

**Descrição:** Método responsável por criar as coordenadas dos vértices do objeto.

#### Sobrecargas
	
- CreateSolidColorVertices().
		
	**Parâmetros:**

	- **Vector3[]** vertices;

		Os Vértices do triângulo condensados em um array Vector3. Cada posição do array corresponde a um vértice e as propriedades X, Y e Z do Vector3 correspondem respectivamente as coordenadas X, Y e Z do vértice.

	**Retorno:** float[];

	**Descrição:** Transforma vértices tipados em Vector3 para vértices legíveis ao opengl em tipo float.

---

### CreateColorVertices()

**Parâmetros:**

- **Vector3** centerPosition;
	
	A coordenada X, Y, Z do ponto central do objeto.

- **Vector3[]** color;

	Os códigos de cor dos vértices do objeto. Pode ser construído apenas de uma maneira, tendo Length = 3;
	
	- **Index [0]:** Código de cor do vértice Inferior esquerdo;
		
	- **Index [1]:** Código de cor do vértice superior;
		
	- **Index [2]:** Código de cor do vértice Inferior direito.

	**Atenção: As propriedades X, Y e Z, do objeto Vector3, correspondem, respectivamente, aos canais Vermelho, Verde e Azul da cor (RGB).**

	**Caso a Length do objeto color seja diferente de 3, uma exceção será lançada, interrompendo a execução do projeto!**

- **float** sideLength;

	O comprimento do lado do objeto.

**Retorno:** float[];

**Descrição:** Método responsável por criar as coordenadas dos vértices do objeto, já mapeadas com suas respectivas cores.

---

### ImplementColorAtributtes()

**Parâmetros:**

- **float[]** vertices;

	Os vértices simples do objeto, sem adição de coordenadas de textura ou códigos de cor. Pode ser apresentado apenas de uma maneira, tendo Length = 9.

	**Atenção: Caso a Length deste parâmetro seja diferente de 9, uma exceção será lançada, interrompendo a execução do projeto!**

- **Vector3[]** colors;

	Os códigos de cor para cada vértice do objeto. Pode ser construído apenas de uma maneira, tendo Length = 3;

	- **Index [0]:** Código de cor do vértice inferior esquerdo;

	- **Index [1]:** Código de cor do vértice superior;

	- **Index [2]:** Código de cor do vértice inferior direito.

	**Lembrete: As propriedades X, Y e Z, do objeto Vector3, correspondem, respectivamente, aos canais Vermelho, Verde e Azul da cor (RGB).**

	**Atenção: Caso a Length deste parâmetro seja diferente de 3, uma exceção será lançada, interrompendo a execução do projeto!**

**Retorno:** float[];

**Descrição:** Transforma vértices normais em vértices com código de cor, partindo da adição dos códigos de cor passados em "colors" as coordenadas de vértices passadas em "vertices".

---

### CreateTextureVertices()

**Parâmetros:**

- **Vector3** centerPosition;

	A coordenada X, Y, Z do ponto central do objeto.

- **float** sideLength;

	O comprimento do lado do objeto.

**Retorno:** float[];

**Descrição:** Cria um array de coordenadas de vértices a partir de uma posição central e o comprimento do lado do objeto.

---

### ImplementTextureVertices()

**Parâmetros:**

- **float[]** vertices;

	Os vértices simples do objeto, sem adição de coordenadas de textura ou códigos de cor. Pode ser apresentado apenas de uma maneira, tendo Length = 9.

	**Atenção: Caso a Length deste parâmetro seja diferente de 9, uma exceção será lançada, interrompendo a execução do projeto!**

- **Vector2[]?** textureCoords;

	As coordenadas de textura a serem aplicadas aos vértices; Subdivide-se em 2 opções: valor nulo e as coordenadas de textura dos 3 vértices do objeto.

	**Opção 1 (valor nulo):**

	- O algoritmo irá criar as coordenadas de textura automaticamente. Certifique-se de mantêr a ordem de vértices padrão; inferior esquerdo, superior e inferior direito, ao fazer uso desse recurso, tendo por finalidade evitar possíveis distorções no mapeamento de textura.

	**Opção 2 (Length = 3):**

	- **Index [0]:** Coordenada de textura (X, Y) do vértice inferior esquerdo;

	- **Index [1]:** Coordenada de textura (X, Y) do vértice superior;

	- **Index [2]:** Coordenada de textura (X, Y) do vértice inferior direito.

**Retorno:** float[];

**Descrição:** Transforma vértices normais em vértices com coordenadas de textura, partindo da adição das coordenadas de textura, passadas em "textureCoords", as coordenadas de vértices, passadas em "vertices".

---