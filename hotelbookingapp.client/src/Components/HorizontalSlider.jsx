import './horizontalSlider.css';

function HorizontalSlider({title, children}) {
  return (
<div className="container-fluid w-100 pt-3">
    <h1 className="text-center">{title}</h1>
    <div className="d-flex flex-row flex-nowrap overflow-auto large-2">
        {children}
    </div>
</div>
  );
}

export default HorizontalSlider;
