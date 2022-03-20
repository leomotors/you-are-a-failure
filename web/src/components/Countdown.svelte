<script lang="ts">
  import { onMount } from "svelte";

  const releaseDate = new Date("1 Apr 2022");
  let time = "Calculating Time...";

  function a(n: number) {
    return n >= 10 ? `${n}` : `0${n}`;
  }

  function update() {
    let rem = releaseDate.getTime() - new Date().getTime();
    rem = Math.floor(rem / 1000);

    let sign = "";
    if (rem < 0) {
      sign = "-";
      rem = -rem;
    }

    const s = rem % 60;
    const tm = Math.floor(rem / 60);
    const m = tm % 60;
    const th = Math.floor(tm / 60);
    const h = tm % 24;
    const d = Math.floor(th / 24);

    return `${sign}${d}:${a(h)}:${a(m)}:${a(s)}`;
  }

  onMount(() => {
    const interval = setInterval(() => {
      time = update();
    }, 1000);

    return () => clearInterval(interval);
  });
</script>

<h1>{time}</h1>
