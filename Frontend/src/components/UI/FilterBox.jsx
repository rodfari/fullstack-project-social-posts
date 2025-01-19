import { useContext } from "react";
import { AppContext } from "../../context/AppContext";
import { ModalContext } from "../../context/ModalContext";
import { TimelineContext } from "../../context/TimeLineContext";

const FilterBox = () => {
  const tmlCtx = useContext(TimelineContext);
  const modalCtx = useContext(ModalContext);

  const handleSubmit = (e) => {
    console.log("submit");
    e.preventDefault();
    tmlCtx.setParam({
      type: "SET_PAGE",
      payload: 1,
    });
    tmlCtx.setParam({
      type: "SET_PAGE_SIZE",
      payload: 15,
    });
    const fd = new FormData(e.target);
    const search = fd.get("search");
    tmlCtx.setParam({
      type: "SET_SEARCH",
      payload: search,
    });
  }

  const sortHandler = (e) => {

    tmlCtx.setParam({
      type: "SET_PAGE",
      payload: 1,
    });
    tmlCtx.setParam({
      type: "SET_PAGE_SIZE",
      payload: 15,
    });
    const sort = e.target.value;
    console.log(sort);
    tmlCtx.setParam({
      type: "SET_SORT",
      payload: sort
    });
  }

  return (
    <>
      <div className="filter-box">
        <div className="filter-box__search">
        <form onSubmit={handleSubmit}>
          <input type="text" placeholder="Search" name="search" />
          <button type="submit">Search</button>
        </form>
        </div>
        <div className="filter-box__sort">

          <select onChange={sortHandler}>
            <option value="desc">latest</option>
            <option value="trending">trending</option>
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
