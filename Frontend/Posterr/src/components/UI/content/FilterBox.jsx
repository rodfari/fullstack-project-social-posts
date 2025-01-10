import { useContext } from "react";
import { ModalContext } from "../../../context/ModalContext";

const FilterBox = () => {
  const modalCtx = useContext(ModalContext);
  return (
    <>
      <div className="filter-box">
        <div className="filter-box__search">
          <input type="text" placeholder="Search" />
          <button>Search</button>
        </div>
        <div className="filter-box__sort">
          <select>
            <option value="newest">Newest</option>
            <option value="trending">Trending</option>
          </select>
        </div>
        <div className="filter-box__new">
          <button onClick={ modalCtx.toggleModal }>New Post</button>
        </div>
      </div>
    </>
  );
};

export default FilterBox;
