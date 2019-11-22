<template>
<div class="inline-flex">
  <selection
    class="mx-2"
    v-for="(selection, index) in selections"
    :key="index"
    :color="selection.color"
    :isSelected="selection.isSelected"
    @click.native="select(selection)"/>
</div>
</template>

<script>
import SelectionComponent from "./Selection";
import { questionService } from "@/services/questionService";

export default {
  components: {
    selection: SelectionComponent
  },
  props: {
    questionId: Number
  },
  data() {
    return {
      selections: [
        {
          color: "green-600",
          isSelected: false,
          value: true
        },
        // {
        //   color: "green-500",
        //   isSelected: false
        // },
        // {
        //   color: "gray-600",
        //   isSelected: false
        // },
        // {
        //   color: "red-500",
        //   isSelected: false
        // },
        {
          color: "red-600",
          isSelected: false,
          value: false
        }
      ],
      currentSelection: null
    };
  },
  mounted() {
    this.select(this.selections[0]);
  },
  methods: {
    select(selection) {
      if (this.currentSelection) {
        this.currentSelection.isSelected = false;
      }

      this.currentSelection = selection;
      this.currentSelection.isSelected = true;

      questionService.setAnswer(this.questionId, this.currentSelection.value);
    }
  }
};
</script>