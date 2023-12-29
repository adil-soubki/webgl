window.shaders = window.shaders || {};
window.shaders.fragmentShaderSource = `
#version 300 es

// fragment shaders don't have a default precision so we need
// to pick one. highp is a good default. It means "high precision"
precision highp float;

// we need to declare an output for the fragment shader
out vec4 color;
// and the input for the fragment shader
in vec4 pos4;

// uniform variable that keeps track of the time
uniform float u_time;

// consts
const float PI = 3.1415926535897932384626433832795;
const float PI_2 = PI / 2.0;
const float PI_3 = PI / 3.0;

void main() {
  vec2 pos = pos4.xy;

  float x = pos4.x;
  float y = pos4.y;
  float offset = (u_time) * 2.0;
  color = vec4(sin(x + offset), cos(y - offset), offset, 1.0);
}
`.trim();
