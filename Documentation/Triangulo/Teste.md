# Triangulo - Teste

Aqui se encontram todas as declarações possíveis para fins de testes dos construtores de vértice da classe Triangulo.

---

## Solid Color Objects

    new Triangulo(Triangulo.CreateSolidColorVertices(new Vector3(0f, 0f, 0f), 1f), new Vector4(0.2f, 1f, 0.2f, 1f), null)

---

## Color Objects

- Criando os vértices diretamente:

        new Triangulo(Triangulo.CreateColorVertices(new Vector3(0.5f, 1f, 0f), 1f, new Vector3[]
        {
            new Vector3(1f, 0f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 0f, 1f)
        }), null)

- Criando os vértices a partir de outros vértices já implementados:

        new Triangulo(Triangulo.ImplementColorAtributtes(Triangulo.CreateSolidColorVertices(new Vector3(-0.5f, 1f, 0f), 1f), new Vector3[]
        {
            new Vector3(1f, 0f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 0f, 1f)
        }), null)

---

## Texture Object

- Criando os vértices diretamente:

        new Triangulo(Triangulo.CreateTextureVertices(new Vector3(0.5f, -1f, 0f), 1f), "Resources/Stone_Texture.jpg", null)

- Criando os vértices a partir de outros vértices já implementados:

        new Triangulo(Triangulo.ImplementTextureAtributtes(Triangulo.CreateSolidColorVertices(new Vector3(-0.5f, -1f, 0f), 1f), new Vector2[]
        {
            new Vector2(0f, 0f),
            new Vector2(0.5f, 1f),
            new Vector2(1f, 0f)
        }), "Resources/Stone_Texture.jpg", null)

    - Utilizando o constrututor automático de coordenadas:

            new Triangulo(Triangulo.ImplementTextureAtributtes(Triangulo.CreateSolidColorVertices(new Vector3(-1f, -1f, 0f), 1f), null), "Resources/Stone_Texture.jpg", null)

---