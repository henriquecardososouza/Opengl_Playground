#version 330 core

in vec3 aPosition;
in vec2 aTexCoord;

out vec2 texCoord;

uniform mat4 transform;

void main(void)
{
    texCoord = aTexCoord;

    gl_Position = vec4(aPosition, 1.0) * transform;
}