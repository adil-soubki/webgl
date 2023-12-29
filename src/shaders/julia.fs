window.shaders = window.shaders || {};
window.shaders.fragmentShaderSource = `
#version 300 es

// fragment shaders don't have a default precision so we need
// to pick one. highp is a good default. It means "high precision"
precision highp float;

// we need to declare an input and output for the fragment shader
in vec4 pos4;
out vec4 color;

// uniform variable that keeps track of the time
uniform float u_time;
int max_iterations = 100;

// consts
const float PI = 3.1415926535897932384626433832795;

vec2 complex_square(vec2 v) {
  return vec2(
    v.x * v.x - v.y * v.y,
    v.x * v.y * 2.0
  );
}

vec2 julia_function(vec2 z, vec2 c) {
  return c + complex_square(z);
}

float iteration_count_to_texture_position(int count) {
  if(count == max_iterations) {
    return 0.0;
  } else {
    return float(count) / float(max_iterations);
  }
}

void main() {
  float zoom = pow(0.5, u_time);
  // vec2 c = vec2(1.0 / u_time - 0.75, 1.0 / u_time - 0.75);
  vec2 c = vec2(0.5, 0.0);
  vec2 z = 1.0 * vec2(
    (pos4.x * zoom - 0.5),
    (pos4.y * zoom - 0.5)
  );
  int count = max_iterations;
  for(int i = 0 ; i < max_iterations; i++)  {
    z = julia_function(z, c);
    if(dot(z, z) > 800.0) {
      count = i;
      break;
    }
  }
  float value = iteration_count_to_texture_position(count) * 2.0;
  color = vec4(
    // 1.0 - sin(value + PI / 5.0),
    // 1.0 - sin(value + PI / 4.0),
    // 1.0 - sin(value + PI / 6.0),
    1.0 - value,
    1.0 - value,
    1.0 - value,
    1.0
  );
}
`.trim();
