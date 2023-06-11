# Retangulo - Teste

Aqui se encontram todas as declarações possíveis para fins de testes dos construtores de vértice da classe Retangulo.

---

## Solid Color Objects

- Utilizando a tecnologia de economia de vértices:

        new Retangulo(Retangulo.CreateSolidColorVertices(new Vector3(1.1f, 0f, 0f), 2f, 1f, true), new Vector4(0.2f, 1f, 0.5f, 1f), null)

- Fazendo a construção normalmente:

        new Retangulo(Retangulo.CreateSolidColorVertices(new Vector3(-1.1f, 0f, 0f), 2f, 1f, false), new Vector4(0.2f, 1f, 0.5f, 1f), null)

---

## Color Objects

- Criando os vértices diretamente:

    **Utilizando a economia de vértices:**

    - Utilizando códigos de cor apenas para os principais vértices:

            new Retangulo(Retangulo.CreateColorVertices(new Vector3(1.1f, 1.1f, 0f), new Vector3[]
            {
                new Vector3(1f, 0f, 0f),
                new Vector3(0f, 1f, 0f),
                new Vector3(0f, 0f, 1f),
                new Vector3(0f, 0f, 0f)
            }, 2f, 1f, true), null)

    - Utilizando códigos de cor para todos os vértices:

            new Retangulo(Retangulo.CreateColorVertices(new Vector3(3.3f, 1.1f, 0f), new Vector3[]
            {
                new Vector3(1f, 0f, 0f), 
                new Vector3(0f, 1f, 0f), 
                new Vector3(0f, 0f, 1f), 
                new Vector3(0f, 1f, 0f), 
                new Vector3(0f, 0f, 1f), 
                new Vector3(0f, 0f, 0f)
            }, 2f, 1f, true), null),
                
    **Construindo normalmente:**

    - Utilizando códigos de cor apenas para os principais vértices:

            new Retangulo(Retangulo.CreateColorVertices(new Vector3(-1.1f, 1.1f, 0f), new Vector3[]
            {
                new Vector3(1f, 0f, 0f),
                new Vector3(0f, 1f, 0f),
                new Vector3(0f, 0f, 1f),
                new Vector3(0f, 0f, 0f)
            }, 2f, 1f, false), null)

    - Utilizando códigos de cor para todos os vértices:

            new Retangulo(Retangulo.CreateColorVertices(new Vector3(-3.3f, 1.1f, 0f), new Vector3[]
            {
                new Vector3(1f, 0f, 0f),
                new Vector3(0f, 1f, 0f),
                new Vector3(0f, 0f, 1f), 
                new Vector3(0f, 1f, 0f),
                new Vector3(0f, 0f, 1f),
                new Vector3(0f, 0f, 0f)
            }, 2f, 1f, false), null)

- Criando os vértices a partir de outros vértices já implementados:

    **Utilizando a economia de vértices:**

    - Utilizando códigos de cor apenas para os principais vértices:

            new Retangulo(Retangulo.ImplementColorAtributtes(Retangulo.CreateSolidColorVertices(new Vector3(5.5f, 1.1f, 0f), 2f, 1f, true), new Vector3[]
                {
                    new Vector3(1f, 0f, 0f),
                    new Vector3(0f, 1f, 0f),
                    new Vector3(0f, 0f, 1f),
                    new Vector3(0f, 0f, 0f)
                }), null)

    - Utilizando códigos de cor para todos os vértices:

            new Retangulo(Retangulo.ImplementColorAtributtes(Retangulo.CreateSolidColorVertices(new Vector3(7.7f, 1.1f, 0f), 2f, 1f, true), new Vector3[]
            {
                new Vector3(1f, 0f, 0f),
                new Vector3(0f, 1f, 0f),
                new Vector3(0f, 0f, 1f), 
                new Vector3(0f, 1f, 0f),
                new Vector3(0f, 0f, 1f), 
                new Vector3(0f, 0f, 0f)
            }), null)

    **Construindo normalmente:**
    
    - Utilizando códigos de cor apenas para os principais vértices:

            new Retangulo(Retangulo.ImplementColorAtributtes(Retangulo.CreateSolidColorVertices(new Vector3(-5.5f, 1.1f, 0f), 2f, 1f, false), new Vector3[]
            {
                new Vector3(1f, 0f, 0f),
                new Vector3(0f, 1f, 0f),
                new Vector3(0f, 0f, 1f),
                new Vector3(0f, 0f, 0f)
            }), null)

    - Utilizando códigos de cor para todos os vértices:

            new Retangulo(Retangulo.ImplementColorAtributtes(Retangulo.CreateSolidColorVertices(new Vector3(-7.7f, 1.1f, 0f), 2f, 1f, false), new Vector3[]
            {
                new Vector3(1f, 0f, 0f),
                new Vector3(0f, 1f, 0f), 
                new Vector3(0f, 0f, 1f), 
                new Vector3(0f, 1f, 0f), 
                new Vector3(0f, 0f, 1f),
                new Vector3(0f, 0f, 0f)
            }), null)

---

## Texture Object

- Criando os vértices diretamente:

    **Utilizando a economia de vértices:**

        new Retangulo(Retangulo.CreateTextureVertices(new Vector3(1.1f, -1.1f, 0f), 2f, 1f, true), "Resources/Stone_Texture.jpg", null)

    **Construindo normalmente:**

        new Retangulo(Retangulo.CreateTextureVertices(new Vector3(-1.1f, -1.1f, 0f), 2f, 1f, false), "Resources/Stone_Texture.jpg", null)

- Criando os vértices a partir de outros vértices já implementados:

    **Utilizando a economia de vértices:**

    - Utilizando coordenadas de textura apenas para os principais vértices:

            new Retangulo(Retangulo.ImplementTextureAtributtes(Retangulo.CreateSolidColorVertices(new Vector3(3.3f, -1.1f, 0f), 2f, 1f, true), new Vector2[]
            {
                new Vector2(0f, 1f),
                new Vector2(1f, 1f),
                new Vector2(0f, 0f),
                new Vector2(1f, 0f)
            }), "Resources/Stone_Texture.jpg", null)

    - Utilizando coordenadas de textura para todos os vértices:

            new Retangulo(Retangulo.ImplementTextureAtributtes(Retangulo.CreateSolidColorVertices(new Vector3(5.5f, -1.1f, 0f), 2f, 1f, true), new Vector2[]
            {
                new Vector2(0f, 1f),
                new Vector2(1f, 1f),
                new Vector2(0f, 0f),
                new Vector2(1f, 1f),
                new Vector2(0f, 0f),
                new Vector2(1f, 0f)
            }), "Resources/Stone_Texture.jpg", null)

    - Utilizando o constrututor automático de coordenadas:

            new Retangulo(Retangulo.ImplementTextureAtributtes(Retangulo.CreateSolidColorVertices(new Vector3(7.7f, -1.1f, 0f), 2f, 1f, true), null), "Resources/Stone_Texture.jpg", null)

    **Construindo normalmente:**

    - Utilizando coordenadas de textura apenas para os principais vértices:

            new Retangulo(Retangulo.ImplementTextureAtributtes(Retangulo.CreateSolidColorVertices(new Vector3(-3.3f, -1.1f, 0f), 2f, 1f, false), new Vector2[]
            {
                new Vector2(0f, 1f),
                new Vector2(1f, 1f),
                new Vector2(0f, 0f),
                new Vector2(1f, 0f)
            }), "Resources/Stone_Texture.jpg", null)

    - Utilizando coordenadas de textura para todos os vértices:

            new Retangulo(Retangulo.ImplementTextureAtributtes(Retangulo.CreateSolidColorVertices(new Vector3(-5.5f, -1.1f, 0f), 2f, 1f, false), new Vector2[]
            {
                new Vector2(0f, 1f),
                new Vector2(1f, 1f),
                new Vector2(0f, 0f),
                new Vector2(1f, 1f),
                new Vector2(0f, 0f),
                new Vector2(1f, 0f)
            }), "Resources/Stone_Texture.jpg", null)

    - Utilizando o constrututor automático de coordenadas:

            new Retangulo(Retangulo.ImplementTextureAtributtes(Retangulo.CreateSolidColorVertices(new Vector3(-7.7f, -1.1f, 0f), 2f, 1f, false), null), "Resources/Stone_Texture.jpg", null)

---