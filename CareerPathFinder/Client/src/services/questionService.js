class QuestionService {
  constructor() {
    this.answers = { };
  }

  getAnswers() {
    return this.answers;
  }

  setAnswer(questionId, value) {
    this.answers[questionId] = value;
  }
}

export const questionService = new QuestionService();