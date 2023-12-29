window.shaders = window.shaders || {};
window.shaders.vertexShaderSource = `
#version 300 es

// an attribute is an input (in) to a vertex shader.
// It will receive data from a buffer
in vec4 i_pos4;
out vec4 pos4;

// all shaders have a main function
void main() {

  // gl_Position is a special variable a vertex shader
  // is responsible for setting
  gl_Position = i_pos4;
  pos4 = i_pos4;
}
`.trim();
