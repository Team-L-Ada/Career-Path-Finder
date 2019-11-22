<template>
<div
  class="rounded-full h-16 w-16"
  :class="[isSelected ? `bg-${color}` : 'bg-gray-300', `hover:bg-${color}`]"/>
</template>

<script>
export default {
  props: {
    color: String,
    isSelected: Boolean
  }
};
</script>