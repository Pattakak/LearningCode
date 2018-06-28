#version 330 core

in vec2 texCoord;
in vec3 fragPos;
in vec3 norm;


out vec4 FragColor;

uniform sampler2D ourTexture;
uniform vec3 lightPos;

float intensityConstant; //This will increase or decrease brightness
float brightness;
vec4 color;

void main() {

//Lighting Mathematics

//lightPos = vec3(-1.0f, 0.0f, -1.0f);
color = vec4(1.0f);
intensityConstant = 10.0f;

vec3 normal = normalize(norm);
vec3 lightDirection = lightPos - fragPos; //Vector that points towards the light
brightness = min(1, max(dot(normalize(lightDirection), normal), 0.0) / length(lightDirection) * intensityConstant); //0.0f is the minimum brightness (complete dark)


//End Mathematics

FragColor = texture(ourTexture, texCoord) * vec4(1.0f) * color * brightness * vec4(1.0f);
//FragColor = vec4(1.0f, 0.0f, 1.0f, 1.0f);
}