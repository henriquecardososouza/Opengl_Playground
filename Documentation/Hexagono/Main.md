# Hexagono

Documentação para uso da classe Hexagono.

## Teste

[**Possíveis declarações da classe Hexagono**](./Teste.md)

---

## Construtores

### Objeto de Cor Sólida

**Sintax:** Hexagono(float[] vertices, Vector3[] color, Matrix4? transformation).

**Descrição:** Inicializa um hexágono preenchido com uma cor sólida.

---

#### Parâmetro 01 - vertices

**Tipo:** Um array do tipo float - float[].

**Descrição:** Os vértices necessários para se desenhar o objeto.

**Sintax:** Esse parâmetro pode ser construído de duas maneiras diferentes:

- **Primeira Forma (O array possui Length = 21):** O array possui somente os vértices da figura final, ou seja, possui apenas os seis vértices do hexágono e o vértice central do objeto;

- **Segunda Forma (O array possui Length = 54):** O array possui todos os vértices dos seis triângulos necessários para se desenhar o héxagono.

	**Sintax Geral:** O array é subdividido em grupos de 3 elementos, ou seja, um grupo de três elementos consecutivos corresponde as coordenadas X, Y e Z de um vértice. **Exemplo:** [0] = Coordenada X, [1] = Coordenada Y, [2] = Coordenada Z...

	**Alerta: Caso o array possua uma Length diferente de 21 ou de 54 uma exceção será lançada, interrompendo a execução do projeto!**

**Ordem:** Segue abaixo a ordem de vértices para esse parâmetro:

**Forma 1 (Length = 21):**

- **1° Vértice (index [0], [1], [2]):** Vértice Superior Esquerdo;

- **2° Vértice (index [3], [4], [5]):** Vértice Superior;

- **3° Vértice (index [6], [7], [8]):** Vértice Superior Direito;

- **4° Vértice (index [9], [10], [11]):** Vértice Inferior Direito;

- **5° Vértice (index [12], [13], [14]):** Vértice Inferior;

- **6° Vértice (index [15], [16], [17]):** Vértice Inferior Esquerdo;

- **7° Vértice (index [18], [19], [20]):** Vértice Central.

**Forma 2 (Length = 54):**

- **1° Triângulo (index [0]...[8]):**

	**1° Vértice (index [0], [1], [2]):** Vértice Superior Esquerdo;

	**2° Vértice (index [3], [4], [5]):** Vértice Superior;

	**3° Vértice (index [6], [7], [8]):** Vértice Central.


- **2° Triângulo (index [9]...[17]):**

	**1° Vértice (index [9], [10], [11]):** Vértice Superior;

	**2° Vértice (index [12], [13], [14]):** Vértice Superior Direito;

	**3° Vértice (index [15], [16], [17]):** Vértice Central.


- **3° Triângulo (index [18]...[26]):**

	**1° Vértice (index [18], [19], [20]):** Vértice Superior Direito;

	**2° Vértice (index [21], [22], [23]):** Vértice Inferior Direito;

	**3° Vértice (index [24], [25], [26]):** Vértice Central.


- **4° Triângulo (index [27]...[35]):**

	**1° Vértice (index [27], [28], [29]):** Vértice Inferior Direito;

	**2° Vértice (index [30], [31], [32]):** Vértice Inferior;

	**3° Vértice (index [33], [34], [35]):** Vértice Central.


- **5° Triângulo (index [36]...[44]):**

	**1° Vértice (index [36], [37], [38]):** Vértice Inferior;

	**2° Vértice (index [39], [40], [41]):** Vértice Inferior Esquerdo;

	**3° Vértice (index [42], [43], [44]):** Vértice Central.


- **6° Triângulo (index [45]...[53]):**

	**1° Vértice (index [45], [46], [47]):** Vértice Inferior Esquerdo;

	**2° Vértice (index [48], [49], [50]):** Vértice Superior Esquerdo;

	**3° Vértice (index [51], [52], [53]):** Vértice Central.

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

**Sintax:** Hexagono(float[] vertices, Matrix4? transformation).

**Descrição:** Inicializa um hexágono preenchido com cores variadas.

---

#### Parâmetro 01 - vertices

**Tipo:** Um array do tipo float - float[].

**Descrição:** Os vértices necessários para se desenhar o objeto juntamente com seus respectivos códigos de cor.

**Sintax:** Esse parâmetro pode ser construído de duas maneiras diferentes:

- **Primeira Forma (O array possui Length = 42):** O array possui somente os vértices da figura final, ou seja, possui apenas os seis vértices do hexágono e o vértice central do objeto;

- **Segunda Forma (O array possui Length = 108):** O array possui todos os vértices dos seis triângulos necessários para se desenhar o héxagono.

	**Sintax Geral:** O array é subdividido em grupos de 6 elementos. Um grupo de seis elementos consecutivos corresponde as coordenadas X, Y e Z e o código de cor de um vértice. **Exemplo:** [0] = Coordenada X, [1] = Coordenada Y, [2] = Coordenada Z, [3] - Canal Vermelho da Cor, [4] - Canal Verde da Cor, [5] - Canal Azul da Cor...

	**Alerta: Caso o array possua uma Length diferente de 42 ou de 108 uma exceção será lançada, interrompendo a execução do projeto!**

**Ordem:** Segue abaixo a ordem de vértices para esse parâmetro:

**Forma 1 (Length = 42):**

- **1° Vértice (index [0]...[5]):** Vértice Superior Esquerdo;
	- **[0], [1], [2]** - Coordenadas X, Y, Z;

	- **[3], [4], [5]** - Código de Cor (RGB).

- **2° Vértice (index [6]...[11]):** Vértice Superior;
	- **[6], [7], [8]** - Coordenadas X, Y, Z;

	- **[9], [10], [11]** - Código de Cor (RGB).

- **3° Vértice (index [12]...[17]):** Vértice Superior Direito;
	- **[12], [13], [14]** - Coordenadas X, Y, Z;

	- **[15], [16], [17]** - Código de Cor (RGB).

- **4° Vértice (index [18]...[23]):** Vértice Inferior Direito;
	- **[18], [19], [20]** - Coordenadas X, Y, Z;

	- **[21], [22], [23]** - Código de Cor (RGB).

- **5° Vértice (index [24]...[29]):** Vértice Inferior;
	- **[24], [25], [26]** - Coordenadas X, Y, Z;

	- **[27], [28], [29]** - Código de Cor (RGB).

- **6° Vértice (index [30]...[35]):** Vértice Inferior Esquerdo;
	- **[30], [31], [32]** - Coordenadas X, Y, Z;

	- **[33], [34], [35]** - Código de Cor (RGB).

- **7° Vértice (index [36]...[41]):** Vértice Central.
	- **[36], [37], [38]** - Coordenadas X, Y, Z;

	- **[39], [40], [41]** - Código de Cor (RGB).

**Forma 2 (Length = 108):**

- **1° Triângulo (index [0]...[17]):**

	**1° Vértice (index [0]...[5]):** Vértice Superior Esquerdo;

	- **[0], [1], [2]** - Coordenadas X, Y, Z;

	- **[3], [4], [5]** - Código de Cor (RGB).

	**2° Vértice (index [6]...[11]):** Vértice Superior;

	- **[6], [7], [8]** - Coordenadas X, Y, Z;

	- **[9], [10], [11]** - Código de Cor (RGB).

	**3° Vértice (index [12]...[17]):** Vértice Central.

	- **[12], [13], [14]** - Coordenadas X, Y, Z;

	- **[15], [16], [17]** - Código de Cor (RGB).


- **2° Triângulo (index [18]...[35]):**

	**1° Vértice (index [18]...[22]):** Vértice Superior;

	- **[18], [19], [20]** - Coordenadas X, Y, Z;

	- **[21], [22], [23]** - Código de Cor (RGB).

	**2° Vértice (index [24]...[29]):** Vértice Superior Direito;

	- **[24], [25], [26]** - Coordenadas X, Y, Z;

	- **[27], [28], [29]** - Código de Cor (RGB).

	**3° Vértice (index [30]...[35]):** Vértice Central.
	
	- **[30], [31], [32]** - Coordenadas X, Y, Z;

	- **[33], [34], [35]** - Código de Cor (RGB).


- **3° Triângulo (index [36]...[53]):**

	**1° Vértice (index [36]...[41]):** Vértice Superior Direito;
	
	- **[36], [37], [38]** - Coordenadas X, Y, Z;

	- **[39], [40], [41]** - Código de Cor (RGB).

	**2° Vértice (index [42]...[47]):** Vértice Inferior Direito;
	
	- **[42], [43], [44]** - Coordenadas X, Y, Z;

	- **[45], [46], [47]** - Código de Cor (RGB).

	**3° Vértice (index [48]...[53]):** Vértice Central.
	
	- **[48], [49], [50]** - Coordenadas X, Y, Z;

	- **[51], [52], [53]** - Código de Cor (RGB).


- **4° Triângulo (index [54]...[71]):**

	**1° Vértice (index [54]...[59]):** Vértice Inferior Direito;
	
	- **[54], [55], [56]** - Coordenadas X, Y, Z;

	- **[57], [58], [59]** - Código de Cor (RGB).

	**2° Vértice (index [60]...[65]):** Vértice Inferior;
	
	- **[60], [61], [62]** - Coordenadas X, Y, Z;

	- **[63], [64], [65]** - Código de Cor (RGB).

	**3° Vértice (index [66]...[71]):** Vértice Central.
	
	- **[66], [67], [68]** - Coordenadas X, Y, Z;

	- **[69], [70], [71]** - Código de Cor (RGB).


- **5° Triângulo (index [72]...[89]):**

	**1° Vértice (index [72]...[77]):** Vértice Inferior;
	
	- **[72], [73], [74]** - Coordenadas X, Y, Z;

	- **[75], [76], [77]** - Código de Cor (RGB).

	**2° Vértice (index [78]...[83]):** Vértice Inferior Esquerdo;
	
	- **[78], [79], [80]** - Coordenadas X, Y, Z;

	- **[81] [82], [83]** - Código de Cor (RGB).

	**3° Vértice (index [84]...[89]):** Vértice Central.
	
	- **[84], [85], [86]** - Coordenadas X, Y, Z;

	- **[87], [88], [89]** - Código de Cor (RGB).


- **6° Triângulo (index [90]...[107]):**

	**1° Vértice (index [90]...[95]):** Vértice Inferior Esquerdo;
	
	- **[90], [91], [92]** - Coordenadas X, Y, Z;

	- **[93], [94], [95]** - Código de Cor (RGB).

	**2° Vértice (index [96]...[101]):** Vértice Superior Esquerdo;
	
	- **[96], [97], [98]** - Coordenadas X, Y, Z;

	- **[99], [100], [101]** - Código de Cor (RGB).

	**3° Vértice (index [102]...[107]):** Vértice Central.
	
	- **[102], [103], [104]** - Coordenadas X, Y, Z;

	- **[105], [106], [107]** - Código de Cor (RGB).

---

#### Parâmetro 02 - transformation

**Tipo:** Um objeto do tipo Matrix4 ou null.

**Descrição:** A transformação que será aplicada ao objeto no momento de sua rendenização.

**Sintax:** Uma Matrix4 simples, podendo variar entre vários propósitos, como ajustar escala, posição ou rotação do objeto.

- **Alerta: Em caso deste parâmetro receber valor null nenhuma transformação será aplicada ao objeto, e esse será rendenizado conforme os vértices passados no parâmetro "vertices".**

---


### Objeto texturizado

**Sintax:** public Hexagono(float[] vertices, string texturePath, Matrix4? transformation).

**Descrição:** Inicializa um hexágono preenchido com textura.

---

#### Parâmetro 01 - vertices

**Tipo:** Um array do tipo float - float[].

**Descrição:** Os vértices necessários para se desenhar o objeto juntamente com suas respectivas coordenadas de textura.

**Sintax:** Esse parâmetro pode ser construído de duas maneiras diferentes:

- **Primeira Forma (O array possui Length = 35):** O array possui somente os vértices da figura final, ou seja, possui apenas os seis vértices do hexágono e o vértice central do objeto;

- **Segunda Forma (O array possui Length = 90):** O array possui todos os vértices dos seis triângulos necessários para se desenhar o héxagono.

	**Sintax Geral:** O array é subdividido em grupos de 5 elementos. Um grupo de cinco elementos consecutivos corresponde as coordenadas X, Y e Z e a coordenada de textura de um vértice. **Exemplo:** [0] = Coordenada X, [1] = Coordenada Y, [2] = Coordenada Z, [3] - Coordenada X de Textura, [4] - Coordenada Y de Textura...

	**Alerta: Caso o array possua uma Length diferente de 35, e diferente de 90, uma exceção será lançada, interrompendo a execução do projeto!**

**Ordem:** Segue abaixo a ordem de vértices para esse parâmetro:

**Forma 1 (Length = 35):**

- **1° Vértice (index [0]...[4]):** Vértice Superior Esquerdo;
	- **[0], [1], [2]** - Coordenadas X, Y, Z;

	- **[3], [4]** - Coordenada X, Y de Textura.

- **2° Vértice (index [5]...[9]):** Vértice Superior;
	- **[5], [6], [7]** - Coordenadas X, Y, Z;

	- **[8], [9]** - Coordenada X, Y de Textura.

- **3° Vértice (index [10]...[14]):** Vértice Superior Direito;
	- **[10], [11], [12]** - Coordenadas X, Y, Z;

	- **[13], [14]** - Coordenada X, Y de Textura.

- **4° Vértice (index [15]...[19]):** Vértice Inferior Direito;
	- **[15], [16], [17]** - Coordenadas X, Y, Z;

	- **[18], [19]** - Coordenada X, Y de Textura.

- **5° Vértice (index [20]...[24]):** Vértice Inferior;
	- **[20], [21], [22]** - Coordenadas X, Y, Z;

	- **[23], [24]** - Coordenada X, Y de Textura.

- **6° Vértice (index [25]...[29]):** Vértice Inferior Esquerdo;
	- **[25], [26], [27]** - Coordenadas X, Y, Z;

	- **[28], [29]** - Coordenada X, Y de Textura.

- **7° Vértice (index [30]...[34]):** Vértice Central.
	- **[30], [31], [32]** - Coordenadas X, Y, Z;

	- **[33], [34]** - Coordenada X, Y de Textura.

**Forma 2 (Length = 90):**

- **1° Triângulo (index [0]...[14]):**

	**1° Vértice (index [0]...[4]):** Vértice Superior Esquerdo;

	- **[0], [1], [2]** - Coordenadas X, Y, Z;

	- **[3], [4]** - Coordenada X, Y de Textura.

	**2° Vértice (index [5]...[9]):** Vértice Superior;

	- **[5], [6], [7]** - Coordenadas X, Y, Z;

	- **[8], [9]** - Coordenada X, Y de Textura.

	**3° Vértice (index [10]...[14]):** Vértice Central.

	- **[10], [11], [12]** - Coordenadas X, Y, Z;

	- **[13], [14]** - Coordenada X, Y de Textura.


- **2° Triângulo (index [15]...[29]):**

	**1° Vértice (index [15]...[19]):** Vértice Superior;

	- **[15], [16], [17]** - Coordenadas X, Y, Z;

	- **[18], [19]** - Coordenada X, Y de Textura.

	**2° Vértice (index [20]...[24]):** Vértice Superior Direito;

	- **[20], [21], [22]** - Coordenadas X, Y, Z;

	- **[23], [24]** - Coordenada X, Y de Textura.

	**3° Vértice (index [25]...[29]):** Vértice Central.
	
	- **[25], [26], [27]** - Coordenadas X, Y, Z;

	- **[28], [29]** - Coordenada X, Y de Textura.


- **3° Triângulo (index [30]...[44]):**

	**1° Vértice (index [30]...[34]):** Vértice Superior Direito;
	
	- **[30], [31], [32]** - Coordenadas X, Y, Z;

	- **[33], [34]** - Coordenada X, Y de Textura.

	**2° Vértice (index [35]...[39]):** Vértice Inferior Direito;
	
	- **[35], [36], [37]** - Coordenadas X, Y, Z;

	- **[38], [39]** - Coordenada X, Y de Textura.

	**3° Vértice (index [40]...[44]):** Vértice Central.
	
	- **[40], [41], [42]** - Coordenadas X, Y, Z;

	- **[43], [44]** - Coordenada X, Y de Textura.


- **4° Triângulo (index [45]...[59]):**

	**1° Vértice (index [45]...[49]):** Vértice Inferior Direito;
	
	- **[45], [46], [47]** - Coordenadas X, Y, Z;

	- **[48], [49]** - Coordenada X, Y de Textura.

	**2° Vértice (index [50]...[54]):** Vértice Inferior;
	
	- **[50], [51], [52]** - Coordenadas X, Y, Z;

	- **[53], [54]** - Coordenada X, Y de Textura.

	**3° Vértice (index [55]...[59]):** Vértice Central.
	
	- **[55], [56], [57]** - Coordenadas X, Y, Z;

	- **[58], [59]** - Coordenada X, Y de Textura.


- **5° Triângulo (index [60]...[74]):**

	**1° Vértice (index [60]...[64]):** Vértice Inferior;
	
	- **[60], [61], [62]** - Coordenadas X, Y, Z;

	- **[63], [64]** - Coordenada X, Y de Textura.

	**2° Vértice (index [65]...[69]):** Vértice Inferior Esquerdo;
	
	- **[65], [66], [67]** - Coordenadas X, Y, Z;

	- **[68], [69]** - Coordenada X, Y de Textura.

	**3° Vértice (index [70]...[74]):** Vértice Central.
	
	- **[70], [71], [72]** - Coordenadas X, Y, Z;

	- **[73], [74]** - Coordenada X, Y de Textura.


- **6° Triângulo (index [75]...[89]):**

	**1° Vértice (index [75]...[79]):** Vértice Inferior Esquerdo;
	
	- **[75], [76], [77]** - Coordenadas X, Y, Z;

	- **[78], [79]** - Coordenada X, Y de Textura.

	**2° Vértice (index [80]...[84]):** Vértice Superior Esquerdo;
	
	- **[80], [81], [82]** - Coordenadas X, Y, Z;

	- **[83], [84]** - Coordenada X, Y de Textura.

	**3° Vértice (index [85]...[89]):** Vértice Central.
	
	- **[85], [86], [87]** - Coordenadas X, Y, Z;

	- **[88], [89]** - Coordenada X, Y de Textura.

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

- **float** sideLength;

	O comprimento do lado do objeto.

- **bool** verticesEconomized;

	Indica se o objeto deve utiizar a tecnologia de vétices reduzidos;

	- **True:** O array retornado irá contêr apenas as coordenadas dos 7 vértices primários do Hexágono; as seis pontas e o ponto central.

	- **False:** O array retornado irá contêr as coordenadas de todos os vértices dos seis triângulos necessários para a construção do hexágono.

**Retorno:** float[];

**Descrição:** Método responsável por criar as coordenadas dos vértices do objeto.

#### Sobrecargas
	
- CreateSolidColorVertices().
		
	**Parâmetros:**

	- **Vector3[]** vertices;

		Os Vértices do hexágono condensados em um array Vector3. Cada posição do array corresponde a um vértice e as propriedades X, Y,e Z do Vector3 correspondem respectivamente as coordenadas X, Y e Z do vértice.

	**Retorno:** float[];

	**Descrição:** Transforma vértices tipados em Vector3 para vértices legíveis ao opengl em tipo float.

---

### CreateColorVertices()

**Parâmetros:**

- **Vector3** centerPosition;
	
	A coordenada X, Y, Z do ponto central do objeto.

- **Vector3[]** color;

	Os códigos de cor dos vértices do objeto. Pode ser construído de duas maneiras: a primeira lista as cores para os sete vértices principais do hexágono, já a segunda opção lista as cores de cada um dos vértices dos seis triângulos constituintes do hexágono.

	**1° Opção (Length = 7):**
		
	- **Index [0]:** Código de cor do vértice superior esquerdo;
		
	- **Index [1]:** Código de cor do vértice superior;
		
	- **Index [2]:** Código de cor do vértice superior direito;
		
	- **Index [3]:** Código de cor do vértice inferior direito;
		
	- **Index [4]:** Código de cor do vértice inferior;
		
	- **Index [5]:** Código de cor do vértice inferior esquerdo;
		
	- **Index [6]:** Código de cor do vértice central.

	**2° Opção (Length = 18):**

	- **1° Triângulo (index [0]...[2]):**

		- **Index [0]:** Código de cor do vértice superior esquerdo;

		- **Index [1]:** Código de cor do vértice superior;

		- **Index [2]:** Código de cor do vértice central.

	- **2° Triângulo (index [3]...[5]):**

		- **Index [3]:** Código de cor do vértice superior;

		- **Index [4]:** Código de cor do vértice superior direito;

		- **Index [5]:** Código de cor do vértice central.

	- **1° Triângulo (index [6]...[8]):**

		- **Index [6]:** Código de cor do vértice superior direito;

		- **Index [7]:** Código de cor do vértice inferior direito;

		- **Index [8]:** Código de cor do vértice central.

	- **1° Triângulo (index [9]...[11]):**

		- **Index [9]:** Código de cor do vértice inferior direito;

		- **Index [10]:** Código de cor do vértice inferior;

		- **Index [11]:** Código de cor do vértice central;

	- **1° Triângulo (index [12]...[14]):**

		- **Index [12]:** Código de cor do vértice inferior;

		- **Index [13]:** Código de cor do vértice inferior esquerdo;

		- **Index [14]:** Código de cor do vértice central;

	- **1° Triângulo (index [15]...[17]):**

		- **Index [15]:** Código de cor do vértice inferior esquerdo;

		- **Index [16]:** Código de cor do vértice superior esquerdo;

		- **Index [17]:** Código de cor do vértice central;

	**Atenção: As propriedades X, Y e Z, do objeto Vector3, correspondem, respectivamente, aos canais Vermelho, Verde e Azul da cor (RGB).**

	**Caso a Length do objeto color seja diferente de 7 ou de 18, uma exceção será lançada, interrompendo a execução do projeto!**

- **float** sideLength;

	O comprimento do lado do objeto.

- **bool** verticesEconomized;

	Indica se o objeto deve utiizar a tecnologia de vétices reduzidos;

	- **True:** O array retornado irá contêr apenas as coordenadas dos 7 vértices primários do Hexágono; as seis pontas e o ponto central.

	- **False:** O array retornado irá contêr as coordenadas de todos os vértices dos seis triângulos necessários para a construção do hexágono.

**Retorno:** float[];

**Descrição:** Método responsável por criar as coordenadas dos vértices do objeto ja mapeadas com suas respectivas cores.

---

### ImplementColorAtributtes()

**Parâmetros:**

- **float[]** vertices;

	Os vértices simples do objeto, sem adição de coordenadas de textura ou códigos de cor. Pode ser apresentado de duas maneiras; na primeira contém apenas as coordenadas dos sete vértices principais do hexágono, e na segunda, contém todas as coordenadas dos vértices dos seis triângulos necessários para a construção do hexágono.

	**Atenção: Caso a Length deste parâmetro seja diferente de 21, e diferente de 54, uma exceção será lançada, interrompendo a execução do projeto!**

- **Vector3[]** colors;

	Os códigos de cor para cada vértice do objeto. Pode ser construído de duas formas; na primeira o array contém os códigos de cor apenas para os sete vértices primários do hexágono. Na segunda, o objeto contém so códigos de cor para cada vértice dos seis triângulos necessários para se construir o hexágono.

	**Opção 1 (Length = 7):**

	- **Index [0]:** Código de cor do vértice superior esquerdo;

	- **Index [1]:** Código de cor do vértice superior;

	- **Index [2]:** Código de cor do vértice superior direito;

	- **Index [3]:** Código de cor do vértice inferior direito;

	- **Index [4]:** Código de cor do vértice inferior;

	- **Index [5]:** Código de cor do vértice inferior esquerdo;

	- **Index [6]:** Código de cor do vértice central.

	**Opção 2 (Length = 18):**

	- **1° Triângulo (index [0]...[2]):**

		- **Index [0]:** Código de cor do vértice superior esquerdo;

		- **Index [1]:** Código de cor do vértice superior;

		- **Index [2]:** Código de cor do vértice central.

	- **2° Triângulo (index [3]...[5]):**

		- **Index [3]:** Código de cor do vértice superior;

		- **Index [4]:** Código de cor do vértice superior direito;

		- **Index [5]:** Código de cor do vértice central.

	- **3° Triângulo (index [6]...[8]):**

		- **Index [6]:** Código de cor do vértice superior direito;

		- **Index [7]:** Código de cor do vértice inferior direito;

		- **Index [8]:** Código de cor do vértice central.

	- **4° Triângulo (index [9]...[11]):**

		- **Index [9]:** Código de cor do vértice inferior direito;

		- **Index [10]:** Código de cor do vértice inferior;

		- **Index [11]:** Código de cor do vértice central.

	- **5° Triângulo (index [12]...[14]):**

		- **Index [12]:** Código de cor do vértice inferior;

		- **Index [13]:** Código de cor do vértice inferior esquerdo;

		- **Index [14]:** Código de cor do vértice central;

	- **6° Triângulo (index [15]...[17]):**

		- **Index [15]:** Código de cor do vértice inferior esquerdo;

		- **Index [16]:** Código de cor do vértice superior esquerdo;

		- **Index [17]:** Código de cor do vértice central;

	**Lembrete: As propriedades X, Y e Z, do objeto Vector3, correspondem, respectivamente, aos canais Vermelho, Verde e Azul da cor (RGB).**

	**Atenção: Caso a Length deste parâmetro seja diferente de 7, e diferente de 18, uma exceção será lançada, interrompendo a execução do projeto!**

**Retorno:** float[];

**Descrição:** Transforma vértices normais em vértices com código de cor, partindo da adição dos códigos de cor passados em "colors" as coordenadas de vértices passadas em "vertices".

---

### CreateTextureVertices()

**Parâmetros:**

- **Vector3** centerPosition;

	A coordenada X, Y, Z do ponto central do objeto.

- **float** sideLength;

	O comprimento do lado do hexágono.

- **bool** verticesEconomized;

	Indica se o objeto deve utiizar a tecnologia de vétices reduzidos;

	- **True:** O array retornado irá contêr apenas as coordenadas dos 7 vértices primários do Hexágono; as seis pontas e o ponto central.

	- **False:** O array retornado irá contêr as coordenadas de todos os vértices dos seis triângulos necessários para a construção do hexágono.

**Retorno:** float[];

**Descrição:** Cria um array de coordenadas de vértices a partir de uma posição central e o comprimento do lado do hexágono.

---

### ImplementTextureVertices()

**Parâmetros:**

- **float[]** vertices;

	Os vértices simples do objeto, sem adição de coordenadas de textura ou códigos de cor. Pode ser apresentado de duas maneiras; na primeira contém apenas as coordenadas dos sete vértices principais do hexágono, e na segunda, contém todas as coordenadas dos vértices dos seis triângulos necessários para a construção do hexágono.

	**Atenção: Caso a Length deste parâmetro seja diferente de 21, e diferente de 54, uma exceção será lançada, interrompendo a execução do projeto!**

- **Vector2[]?** textureCoords;

	As coordenadas de textura a serem aplicadas aos vértices; Subdivide-se em 3 opções: valor nulo, as coordenadas de textura dos sete vértices principais do hexágono e as coordenadas de textura de todos os vértices de cada um dos seis triângulos necessários para a formação do hexágono.

	**Opção 1 (valor nulo):**

	- O algoritmo irá criar as coordenadas de textura automaticamente. Certifique-se de mantêr a ordem de vértices padrão, superior esquerdo, superior, superior direito, inferior direito, inferior, inferior esquerdo e central, ao fazer uso desse recurso, tendo por finalidade evitar possíveis distorções no mapeamento de textura.

	**Opção 2 (Length = 7):**

	- **Index [0]:** Coordenada de textura (X, Y) do vértice superior esquerdo;

	- **Index [1]:** Coordenada de textura (X, Y) do vértice superior;

	- **Index [2]:** Coordenada de textura (X, Y) do vértice superior direito;

	- **Index [3]:** Coordenada de textura (X, Y) do vértice inferior direito;

	- **Index [4]:** Coordenada de textura (X, Y) do vértice inferior;

	- **Index [5]:** Coordenada de textura (X, Y) do vértice inferior esquerdo;

	- **Index [6]:** Coordenada de textura (X, Y) do vértice central.

	**Opção 3 (Length = 18):**

	- **1° Triângulo (index [0]...[2]):**

		- **Index [0]:** Vértice superior esquerdo;

		- **Index [1]:** Vértice superior;

		- **Index [2]:** Vértice central.

	- **2° Triângulo (index [3]...[5]):**

		- **Index [3]:** Vértice superior;

		- **Index [4]:** Vértice superior direito;

		- **Index [5]:** Vértice central.

	- **3° Triângulo (index [6]...[8]):**

		- **Index [6]:** Vértice superior direito;

		- **Index [7]:** Vértice inferior direito;

		- **Index [8]:** Vértice central.

	- **4° Triângulo (index [9]...[11]):**

		- **Index [9]:** Vértice inferior direito;

		- **Index [10]:** Vértice inferior;

		- **Index [11]:** Vértice central.

	- **5° Triângulo (index [12]...[14]):**

		- **Index [12]:** Vértice inferior;

		- **Index [13]:** Vértice inferior esquerdo;

		- **Index [14]:** Vértice central.

	- **6° Triângulo (index [15]...[17]):**

		- **Index [15]:** Vértice inferior esquerdo;

		- **Index [16]:** Vértice superior esquerdo;

		- **Index [17]:** Vértice central;

**Retorno:** float[];

**Descrição:** Transforma vértices normais em vértices com coordenadas de textura, partindo da adição das coordenadas de textura, passadas em "textureCoords", as coordenadas de vértices, passadas em "vertices".

---

### CreateIndices()

**Parâmetros:**

- **bool** verticesEconomized;

	Indica se os índices devem corresponder a coordenadas de vértices otimizadas ou sem otimização.

**Retorno:** uint[];

**Descrição:** Constrói automaticamente os índices de mapeamento dos vértices de triângulos.

**Atenção: O método constrói índices para vértices construídos seguindo a ordem padrão; superior esquerdo, superior, superior direito, inferior direito, inferior, inferior esquerdo e central. Caso os vértices não respeitem essa ordem, distorções podem ocorrer ao objeto!**