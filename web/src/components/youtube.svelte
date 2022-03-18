<script lang="ts">
  export let src: string;
</script>

<div class="container mx-auto">
  <iframe
    class="mx-auto responsive-iframe"
    {src}
    title="YouTube video player"
    frameborder="0"
    allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
    allowfullscreen
  />
</div>

<style lang="css">
  .container {
    max-width: 640px;
    max-height: 360px;
    position: relative;
    overflow: hidden;
    width: 100%;
    padding-top: 56.25%;
  }
  .responsive-iframe {
    position: absolute;
    top: 0;
    left: 0;
    bottom: 0;
    right: 0;
    width: 100%;
    height: 100%;
  }
</style>
