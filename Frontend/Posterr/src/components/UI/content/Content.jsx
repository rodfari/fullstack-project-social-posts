import FilterBox from "./FilterBox";

const Content = () => {
  return (
    <>
      <div className="content">
      <FilterBox />
        <div className="post-box">
          <div className="post">
            <div className="post__user">
              <div className="post__user-avatar">R</div>
              <div className="post__user-name">User name</div>
            </div>
            <div className="post__content">
              <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec
                nec odio nec odio. Nullam sit amet justo in odio ultrices
                consectetur. Donec nec odio nec odio. Nullam sit amet justo in
                odio ultrices consectetur.
              </p>
            </div>
            <div className="post__date">
              <p>2021-09-01</p>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Content;
