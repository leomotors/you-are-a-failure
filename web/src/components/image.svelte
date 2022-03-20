<script lang="ts">
  export let img: string;
  export let full: undefined | true = undefined;

  const Images = {
    "Emotional Damage GIF":
      "https://c.tenor.com/K9-SqJMNjkEAAAAC/emotional-damage.gif",
    "Adagaki Aki": "AdagakiAki.webp",
    "Levi to Erwin": "https://i.ytimg.com/vi/0Hp-U63b56s/maxresdefault.jpg",
    "Zeke Monke":
      "https://sportshub.cbsistatic.com/i/2022/01/11/e3a2e49e-5b45-48f7-a406-2a094aceb6b4/attack-on-titan-season-4-zeke-survives.jpg",
    "Eren Manipulates Grisha":
      "https://i.ytimg.com/vi/W2R4aOkT7cc/maxresdefault.jpg",
  };

  function getImage(key: string) {
    return Images[key] ?? key;
  }
</script>

<img
  class="mx-auto"
  src={getImage(img)}
  alt=""
  width={full ? 960 : 640}
  {...$$restProps}
/>
