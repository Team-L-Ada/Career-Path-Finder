<template>
    <form class="border border-solid border-black" action="action_page.php" method="post">
  <div class="imgcontainer">
  </div>

  <div class="container">
    <label for="uname"><b>Username</b></label> <br>
    <input class="border-2" type="text" placeholder="Enter Username" name="uname" required><br>

    <label for="psw"><b>Password</b></label><br>
    <input class="border-2" type="password" placeholder="Enter Password" name="psw" required><br>

    <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full" type="submit">Login</button><br>
    <label>
      <input type="checkbox" checked="checked" name="remember"> Remember me
    </label><br>
  </div>

  <div class="container" style="background-color:#f1f1f1">
    <button type="button" class="cancelbtn  text-red-700">Cancel</button><br>
    <span class="psw text-blue-600">Forgot <a href="#">password?</a></span><br>
  </div>
</form>
</template>