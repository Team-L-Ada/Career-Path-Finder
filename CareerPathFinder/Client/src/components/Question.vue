<template>
<div class="flex flex-col items-center bg-gray-200 px-5 py-3">
  <span class="w-64">
    <span>{{ questionId }}. </span>
    <slot/>
  </span>
  <div class="flex">
    <selection-label>Agree</selection-label>
    <selection-array :questionId="questionId"></selection-array>
    <selection-label>Disagree</selection-label>
  </div>
</div>
</template>

<script>
import SelectionArrayComponent from "./SelectionArray";
import SelectionLabelComponent from "./SelectionLabel";

export default {
  components: {
    "selection-array": SelectionArrayComponent,
    "selection-label": SelectionLabelComponent
  },
  props: {
    questionId: Number
  }
};
</script>