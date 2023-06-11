# Hexagono - Teste

Aqui se encontram todas as declarações possíveis para fins de testes dos construtores de vértice da classe Hexagono.

---

## Solid Color Objects

- Utilizando a tecnologia de economia de vértices:

        new Hexagono(Hexagono.CreateSolidColorVertices(new Vector3(-0.8f, 1.6f, 0), 0.8f, true), new Vector4(0.5f, 0.1f, 0.1f, 0f), null)

- Fazendo a construção normalmente:

        new Hexagono(Hexagono.CreateSolidColorVertices(new Vector3(0.8f, 1.6f, 0), 0.8f, false), new Vector4(0.5f, 0.1f, 0.1f, 0f), null)

---

## Color Objects

- Criando os vértices diretamente:

    **Utilizando a economia de vértices:**

    - Utilizando códigos de cor apenas para os principais vértices:

            new Hexagono(Hexagono.CreateColorVertices(new Vector3(-5.6f, -1.6f, 0), new Vector3[] {
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, 0, 1),
                new Vector3(1, 1, 0),
                new Vector3(0, 1, 1),
                new Vector3(1, 0, 1),
                new Vector3(1, 1, 1),
            }, 0.8f, true), null),

    - Utilizando códigos de cor para todos os vértices:

            new Hexagono(Hexagono.CreateColorVertices(new Vector3(-2.4f, -1.6f, 0), new Vector3[] {
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(1, 1, 1),

                new Vector3(0, 1, 0),
                new Vector3(0, 0, 1),
                new Vector3(1, 1, 1),

                new Vector3(0, 0, 1),
                new Vector3(1, 1, 0),
                new Vector3(1, 1, 1),

                new Vector3(1, 1, 0),
                new Vector3(0, 1, 1),
                new Vector3(1, 1, 1),

                new Vector3(0, 1, 1),
                new Vector3(1, 0, 1),
                new Vector3(1, 1, 1),

                new Vector3(1, 0, 1),
                new Vector3(1, 0, 0),
                new Vector3(1, 1, 1),
            }, 0.8f, true), null),
                
    **Construindo normalmente:**

    - Utilizando códigos de cor apenas para os principais vértices:

            new Hexagono(Hexagono.CreateColorVertices(new Vector3(-4f, -1.6f, 0), new Vector3[] {
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, 0, 1),
                new Vector3(1, 1, 0),
                new Vector3(0, 1, 1),
                new Vector3(1, 0, 1),
                new Vector3(1, 1, 1),
            }, 0.8f, false), null),

    - Utilizando códigos de cor para todos os vértices:

            new Hexagono(Hexagono.CreateColorVertices(new Vector3(-0.8f, -1.6f, 0), new Vector3[] {
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(1, 1, 1),

                new Vector3(0, 1, 0),
                new Vector3(0, 0, 1),
                new Vector3(1, 1, 1),

                new Vector3(0, 0, 1),
                new Vector3(1, 1, 0),
                new Vector3(1, 1, 1),

                new Vector3(1, 1, 0),
                new Vector3(0, 1, 1),
                new Vector3(1, 1, 1),

                new Vector3(0, 1, 1),
                new Vector3(1, 0, 1),
                new Vector3(1, 1, 1),

                new Vector3(1, 0, 1),
                new Vector3(1, 0, 0),
                new Vector3(1, 1, 1),
            }, 0.8f, false), null),

- Criando os vértices a partir de outros vértices já implementados:

    **Utilizando a economia de vértices:**

    - Utilizando códigos de cor apenas para os principais vértices:

            new Hexagono(Hexagono.ImplementColorAtributtes(Hexagono.CreateSolidColorVertices(new Vector3(4f, -1.6f, 0), 0.8f, true), new Vector3[] {
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, 0, 1),
                new Vector3(1, 1, 0),
                new Vector3(0, 1, 1),
                new Vector3(1, 0, 1),
                new Vector3(1, 1, 1),
            }), null),

    - Utilizando códigos de cor para todos os vértices:

            new Hexagono(Hexagono.ImplementColorAtributtes(Hexagono.CreateSolidColorVertices(new Vector3(0.8f, -1.6f, 0), 0.8f, true), new Vector3[] {
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(1, 1, 1),

                new Vector3(0, 1, 0),
                new Vector3(0, 0, 1),
                new Vector3(1, 1, 1),

                new Vector3(0, 0, 1),
                new Vector3(1, 1, 0),
                new Vector3(1, 1, 1),

                new Vector3(1, 1, 0),
                new Vector3(0, 1, 1),
                new Vector3(1, 1, 1),

                new Vector3(0, 1, 1),
                new Vector3(1, 0, 1),
                new Vector3(1, 1, 1),

                new Vector3(1, 0, 1),
                new Vector3(1, 0, 0),
                new Vector3(1, 1, 1),
            }), null),

    **Construindo normalmente:**
    
    - Utilizando códigos de cor apenas para os principais vértices:

            new Hexagono(Hexagono.ImplementColorAtributtes(Hexagono.CreateSolidColorVertices(new Vector3(5.6f, -1.6f, 0), 0.8f, false), new Vector3[] {
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, 0, 1),
                new Vector3(1, 1, 0),
                new Vector3(0, 1, 1),
                new Vector3(1, 0, 1),
                new Vector3(1, 1, 1),
            }), null),

    - Utilizando códigos de cor para todos os vértices:

            new Hexagono(Hexagono.ImplementColorAtributtes(Hexagono.CreateSolidColorVertices(new Vector3(2.4f, -1.6f, 0), 0.8f, false), new Vector3[] {
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(1, 1, 1),

                new Vector3(0, 1, 0),
                new Vector3(0, 0, 1),
                new Vector3(1, 1, 1),

                new Vector3(0, 0, 1),
                new Vector3(1, 1, 0),
                new Vector3(1, 1, 1),

                new Vector3(1, 1, 0),
                new Vector3(0, 1, 1),
                new Vector3(1, 1, 1),

                new Vector3(0, 1, 1),
                new Vector3(1, 0, 1),
                new Vector3(1, 1, 1),

                new Vector3(1, 0, 1),
                new Vector3(1, 0, 0),
                new Vector3(1, 1, 1),
            }), null)

---

## Texture Object

- Criando os vértices diretamente:

    **Utilizando a economia de vértices:**

        new Hexagono(Hexagono.CreateTextureVertices(new Vector3(4f, 0, 0), 0.8f, true), "Resources/Brick_Wall_Texture.jpg", null)

    **Construindo normalmente:**

        new Hexagono(Hexagono.CreateTextureVertices(new Vector3(5.6f, 0, 0), 0.8f, false), "Resources/Brick_Wall_Texture.jpg", null)

- Criando os vértices a partir de outros vértices já implementados:

    **Utilizando a economia de vértices:**

    - Utilizando coordenadas de textura apenas para os principais vértices:

            new Hexagono(Hexagono.ImplementTextureAtributtes(Hexagono.CreateSolidColorVertices(new Vector3(-5.6f, 0, 0), 0.8f, true), new Vector2[]
            {
                new Vector2(0f, 0.75f),
                new Vector2(0.5f, 1f),
                new Vector2(1f, 0.75f),
                new Vector2(1f, 0.25f),
                new Vector2(0.5f, 0f),
                new Vector2(0f, 0.25f),
                new Vector2(0.5f, 0.5f),
            }), "Resources/Brick_Wall_Texture.jpg", null)

    - Utilizando coordenadas de textura para todos os vértices:

            new Hexagono(Hexagono.ImplementTextureAtributtes(Hexagono.CreateSolidColorVertices(new Vector3(-2.4f, 0, 0), 0.8f, true), new Vector2[]
            {
                new Vector2(0f, 0.75f),
                new Vector2(0.5f, 1f),
                new Vector2(0.5f, 0.5f),

                new Vector2(0.5f, 1f),
                new Vector2(1f, 0.75f),
                new Vector2(0.5f, 0.5f),

                new Vector2(1f, 0.75f),
                new Vector2(1f, 0.25f),
                new Vector2(0.5f, 0.5f),

                new Vector2(1f, 0.25f),
                new Vector2(0.5f, 0f),
                new Vector2(0.5f, 0.5f),

                new Vector2(0.5f, 0f),
                new Vector2(0f, 0.25f),
                new Vector2(0.5f, 0.5f),

                new Vector2(0f, 0.25f),
                new Vector2(0f, 0.75f),
                new Vector2(0.5f, 0.5f),
            }), "Resources/Brick_Wall_Texture.jpg", null)

    - Utilizando o constrututor automático de coordenadas:

            new Hexagono(Hexagono.ImplementTextureAtributtes(Hexagono.CreateSolidColorVertices(new Vector3(0.8f, 0, 0), 0.8f, true), null), "Resources/Brick_Wall_Texture.jpg", null)

    **Construindo normalmente:**

    - Utilizando coordenadas de textura apenas para os principais vértices:

            new Hexagono(Hexagono.ImplementTextureAtributtes(Hexagono.CreateSolidColorVertices(new Vector3(-4f, 0, 0), 0.8f, false), new Vector2[]
            {
                new Vector2(0f, 0.75f),
                new Vector2(0.5f, 1f),
                new Vector2(1f, 0.75f),
                new Vector2(1f, 0.25f),
                new Vector2(0.5f, 0f),
                new Vector2(0f, 0.25f),
                new Vector2(0.5f, 0.5f),
            }), "Resources/Brick_Wall_Texture.jpg", null)

    - Utilizando coordenadas de textura para todos os vértices:

            new Hexagono(Hexagono.ImplementTextureAtributtes(Hexagono.CreateSolidColorVertices(new Vector3(-0.8f, 0, 0), 0.8f, false), new Vector2[]
            {
                new Vector2(0f, 0.75f),
                new Vector2(0.5f, 1f),
                new Vector2(0.5f, 0.5f),

                new Vector2(0.5f, 1f),
                new Vector2(1f, 0.75f),
                new Vector2(0.5f, 0.5f),

                new Vector2(1f, 0.75f),
                new Vector2(1f, 0.25f),
                new Vector2(0.5f, 0.5f),


                new Vector2(1f, 0.25f),
                new Vector2(0.5f, 0f),
                new Vector2(0.5f, 0.5f),

                new Vector2(0.5f, 0f),
                new Vector2(0f, 0.25f),
                new Vector2(0.5f, 0.5f),

                new Vector2(0f, 0.25f),
                new Vector2(0f, 0.75f),
                new Vector2(0.5f, 0.5f),
            }), "Resources/Brick_Wall_Texture.jpg", null)

    - Utilizando o constrututor automático de coordenadas:

            new Hexagono(Hexagono.ImplementTextureAtributtes(Hexagono.CreateSolidColorVertices(new Vector3(0.8f, 0, 0), 0.8f, false), null), "Resources/Brick_Wall_Texture.jpg", null)

---