# Opengl Playground

Um mini playground para fins de teste de rendenização de objetos utilizando OpenGl.

---

## Funcionalidades

O projeto conta com um sistema automático de rendenização de objetos.

Atualmente conta com uma pequena lista de objetos disponíveis, mas em breve novos objetos serão adicionados.

O projeto conta com três métodos de rendenização de objetos, objetos preenchidos com cores sólidas, objetos com cores variadas e objetos texturizados.

---

## Utilização

Para se utilizar do sistema automático de rendenização de objetos, apenas é necessária a instanciação de algum dos objetos disponíveis.

Essa instanciação deve ser realizada no método OnLoad() da classe Window, como um elemento do array _renderObjects (Window.cs - linha: 24).

**Exemplo:**

		_renderObjects = new RenderObject[] {
			new Triangulo(Triangulo.CreateSolidColorVertices(new Vector3(0f, 0f, 0f), 1f), new Vector4(1f, 0f, 0f, 1f), null)
			.
			.
			.
			new Cubo(Cubo.CreateTextureVertices(new Vector3(0f, 0f, 0f), 1f, false), "Resources/Brick_Wall_Texture.jpg", RenderObject.CreateRotationX(90f))
		}

---

## Objetos Disponíveis

Aqui encontra-se uma [**lista**](/Documentation/Objetos.md) com todos os objetos disponíveis e suas respectivas documentações.