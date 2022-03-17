<script lang="ts">
  export let img: keyof typeof Images;

  const Images = {
    "Emotional Damage GIF":
      "https://c.tenor.com/K9-SqJMNjkEAAAAC/emotional-damage.gif",
    "Adagaki Aki": "AdagakiAki.webp",
    "Levi to Erwin": "https://i.ytimg.com/vi/0Hp-U63b56s/maxresdefault.jpg",
    "Zeke Monke":
      "https://sportshub.cbsistatic.com/i/2022/01/11/e3a2e49e-5b45-48f7-a406-2a094aceb6b4/attack-on-titan-season-4-zeke-survives.jpg",
    "My Set Goal": "MySetGoal.webp",
    "Failure Failure": "FailureApp1.webp",
    "Eren Manipulates Grisha":
      "https://i.ytimg.com/vi/W2R4aOkT7cc/maxresdefault.jpg",
  };
</script>

<img class="mx-auto" src={Images[img]} alt="" width="640" {...$$restProps} />
