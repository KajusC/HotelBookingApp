function HorizontalSlider({ title, children }) {
  return (
    <div className="overflow-x-auto md:overflow-x-auto overflow-y-auto">
      <h1 className="text-center">{title}</h1>
      <div className="flex flex-nowrap md:flex-row w-auto md:w-[40rem] flex-col gap-5 md:px-0">
        {children}
      </div>
    </div>
  );
}

export default HorizontalSlider;
