<template>
<form class="border border-solid border-black" action="action_page.php">
  <div class="container">
    <h1>Register</h1>
    <p>Please fill in this form to create an account.</p>
    <hr>

    <label for="email"><b>Email</b></label> <br>
    <input class="border-2" type="text" placeholder="Enter Email" name="email" required> <br>

    <label for="psw"><b>Password</b></label> <br>
    <input class="border-2" type="password" placeholder="Enter Password" name="psw" required> <br>

    <label for="psw-repeat"><b>Repeat Password</b></label> <br>
    <input class="border-2" type="password" placeholder="Repeat Password" name="psw-repeat" required> <br>
    <hr>

    <p>By creating an account you agree to our <a class="text-blue-600" href="#">Terms & Privacy</a>.</p>
    <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full" type="submit" >Register</button>
  </div>

  <div class="container signin">
    <p>Already have an account? <router-link class="text-blue-600" to="/login">Sign in</router-link></p>
  </div>
</form>
</template>