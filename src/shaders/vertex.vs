window.shaders = window.shaders || {};
window.shaders.vertexShaderSource = `
#version 300 es

// an attribute is an input (in) to a vertex shader.
// It will receive data from a buffer
in vec4 a_position;
out vec4 pos4;

// all shaders have a main function
void main() {

  // gl_Position is a special variable a vertex shader
  // is responsible for setting
  gl_Position = a_position;
  pos4 = a_position;
}
`.trim();
