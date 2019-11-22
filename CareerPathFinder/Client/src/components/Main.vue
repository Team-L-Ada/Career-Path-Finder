<template>
<div>
  <div class="flex flex-col items-center">
    <h1 class="">Career Path Finder &#128540;</h1>
    <div class="">
      <question
        class="my-2"
        v-for="(question, index) of questions"
        :key="question"
        :questionId="index + 1">{{ question }}</question>
    </div>
    <button
      class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded outline-none"
      @click="submitAnswers">
      Submit
    </button>

    <div v-if="showPie" class="mt-5">
      <h1 class="text-lg font-bold">Your Results</h1>
      <div class="flex flex-row">
        <div
          class="rounded-full w-32 h-32 self-center mr-5 pie-chart"
          :style="pieProportions"></div>
        <div class="">
          <div class="text-left my-2" v-for="(value, index) of pieChartKeys" :key="index">
            <div class="rounded-full w-10 h-10 p-1 align-middle inline-block" :style="{ 'background-color': colors[index] }">
              {{ Math.round(response[index].percentage * 100) }}%
            </div>
            {{ value }}

            <a :href="hrefs[response[index].name]" target="_blank" class="inline w-6 h-6 rounded-full bg-blue-500 text-white ml-auto w-full font-bold"> 
              <span>
                &rarr;	
              </span>
            </a>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import axios from "axios";
import QuestionComponent from "./Question";
import { questionService } from "@/services/questionService";

export default {
  components: {
    question: QuestionComponent
  },
  data() {
    return {
      questions: [],
      showPie: false,
      pieProportions: { },
      pieChartKeys: [],
      response: null,
      colors: ["#E74C3C", "#9B59B6", "#3498DB", "#1ABC9C", "#E67E22", "#CACFD2"],
      hrefs: {
        'Web or App Development': 'https://skillcrush.com/2019/03/19/how-to-start-a-web-developer-career/',
        'eCommerce Entrepeneurship': 'https://www.entrepreneur.com/article/321869',
        'Digital Marketing': 'https://www.prospects.ac.uk/jobs-and-work-experience/job-sectors/marketing-advertising-and-pr/how-to-get-into-digital-marketing',
        'Technology Sales': 'https://www.notgoingtouni.co.uk/sector/technology',
        'Tech Consultant': 'https://www.pwc.co.uk/careers/student-jobs/work-for-us/graduateopportunities/technology/tech-consulting.html',
        'Test Engineer': 'https://www.academicinvest.com/engineering-careers/civil-engineering-careers/how-to-become-a-test-engineer'
      }
    };
  },
  async beforeCreate() {
    this.questions = (await axios.get("/api/questions/all")).data;
  },
  methods: {
    async submitAnswers() {
      try {
        const response = await axios.post("/api/questions/answer",
          questionService.getAnswers(),
          {
            headers: {
              "Content-Type": "application/json"
            }
          });

        let sum = 0;
        const gradientValues = [];

        response.data.careerMatches.sort((a, b) => b.percentage - a.percentage);

        this.response = response.data.careerMatches;
        this.pieChartKeys = response.data.careerMatches.map(v => v.name);

        for (const value of response.data.careerMatches) {
          sum += value.percentage;
          gradientValues.push(sum * 100);
        }

        this.paintGradient(gradientValues);
      } catch (error) {
        console.error(error);
      }
    },
    paintGradient(gradientValues) {
      this.showPie = true;
      this.pieProportions = { background: `conic-gradient(${this.colors[0]} ${gradientValues[0]}%, ${this.colors[1]} 0 ${gradientValues[1]}%, ${this.colors[2]} 0 ${gradientValues[2]}%, ${this.colors[3]} 0 ${gradientValues[3]}%, ${this.colors[4]} 0 ${gradientValues[4]}%, ${this.colors[5]} 0 ${gradientValues[5]}%)` };
    }
  }
};
</script>