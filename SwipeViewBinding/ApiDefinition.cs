﻿using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SwipeViewBinding
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
	//
	[Protocol]
	[BaseType (typeof (UIView))]
	public partial interface SwipeView {


		[Export ("dataSource", ArgumentSemantic.Assign)]
		SwipeViewDataSource DataSource { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		SwipeViewDelegate Delegate { get; set; }


		[Export ("numberOfItems")]
		int NumberOfItems { get; }

		[Export ("numberOfPages")]
		int NumberOfPages { get; }

		[Export ("itemSize")]
		SizeF ItemSize { get; }

		[Export ("itemsPerPage")]
		int ItemsPerPage { get; set; }

		[Export ("truncateFinalPage")]
		bool TruncateFinalPage { get; set; }

		[Export ("indexesForVisibleItems", ArgumentSemantic.Retain)]
		NSObject [] IndexesForVisibleItems { get; }

		[Export ("visibleItemViews", ArgumentSemantic.Retain)]
		NSObject [] VisibleItemViews { get; }

		[Export ("currentItemView", ArgumentSemantic.Retain)]
		UIView CurrentItemView { get; }

		[Export ("currentItemIndex")]
		int CurrentItemIndex { get; set; }

		[Export ("currentPage")]
		int CurrentPage { get; set; }

		[Export ("alignment")]
		SwipeViewAlignment Alignment { get; set; }

		[Export ("scrollOffset")]
		float ScrollOffset { get; set; }

		[Export ("pagingEnabled")]
		bool PagingEnabled { [Bind ("isPagingEnabled")] get; set; }

		[Export ("scrollEnabled")]
		bool ScrollEnabled { [Bind ("isScrollEnabled")] get; set; }

		[Export ("wrapEnabled")]
		bool WrapEnabled { [Bind ("isWrapEnabled")] get; set; }

		[Export ("delaysContentTouches")]
		bool DelaysContentTouches { get; set; }

		[Export ("bounces")]
		bool Bounces { get; set; }

		[Export ("decelerationRate")]
		float DecelerationRate { get; set; }

		[Export ("autoscroll")]
		float Autoscroll { get; set; }

		[Export ("dragging")]
		bool Dragging { [Bind ("isDragging")] get; }

		[Export ("decelerating")]
		bool Decelerating { [Bind ("isDecelerating")] get; }

		[Export ("scrolling")]
		bool Scrolling { [Bind ("isScrolling")] get; }

		[Export ("defersItemViewLoading")]
		bool DefersItemViewLoading { get; set; }

		[Export ("vertical")]
		bool Vertical { [Bind ("isVertical")] get; set; }

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("initWithFrame:")]
		IntPtr Constructor(RectangleF frame);

		[Export ("reloadItemAtIndex:")]
		void ReloadItemAtIndex (int index);

		[Export ("scrollByOffset:duration:")]
		void ScrollByOffset (float offset, double duration);

		[Export ("scrollToOffset:duration:")]
		void ScrollToOffset (float offset, double duration);

		[Export ("scrollByNumberOfItems:duration:")]
		void ScrollByNumberOfItems (int itemCount, double duration);

		[Export ("scrollToItemAtIndex:duration:")]
		void ScrollToItemAtIndex (int index, double duration);

		[Export ("scrollToPage:duration:")]
		void ScrollToPage (int page, double duration);

		[Export ("itemViewAtIndex:")]
		UIView ItemViewAtIndex (int index);

		[Export ("indexOfItemView:")]
		int IndexOfItemView (UIView view);

		[Export ("indexOfItemViewOrSubview:")]
		int IndexOfItemViewOrSubview (UIView view);
	}

	[Protocol]
	[Model, BaseType (typeof (NSObject))]
	public partial interface SwipeViewDataSource {

		[Export ("numberOfItemsInSwipeView:")]
		int NumberOfItemsInSwipeView (SwipeView swipeView);

		[Export ("swipeView:viewForItemAtIndex:reusingView:")]
		UIView SwipeView (SwipeView swipeView, int index, UIView view);
	}

	[Protocol]
	[Model, BaseType (typeof (NSObject))]
	public partial interface SwipeViewDelegate {

		[Export ("swipeViewItemSize:")]
		SizeF  SwipeViewItemSize(SwipeView swipeView);

		[Export ("swipeViewDidScroll:")]
		void  SwipeViewDidScroll(SwipeView swipeView);

		[Export ("swipeViewCurrentItemIndexDidChange:")]
		void  SwipeViewCurrentItemIndexDidChange(SwipeView swipeView);

		[Export ("swipeViewWillBeginDragging:")]
		void  SwipeViewWillBeginDragging(SwipeView swipeView);

		[Export ("swipeViewDidEndDragging:willDecelerate:")]
		void SwipeViewDidEndDragging (SwipeView swipeView, bool decelerate);

		[Export ("swipeViewWillBeginDecelerating:")]
		void  SwipeViewWillBeginDecelerating(SwipeView swipeView);

		[Export ("swipeViewDidEndDecelerating:")]
		void  SwipeViewDidEndDecelerating(SwipeView swipeView);

		[Export ("swipeViewDidEndScrollingAnimation:")]
		void  SwipeViewDidEndScrollingAnimation(SwipeView swipeView);

		[Export ("swipeView:shouldSelectItemAtIndex:")]
		bool ShouldSelectItemAtIndex (SwipeView swipeView, int index);

		[Export ("swipeView:didSelectItemAtIndex:")]
		void DidSelectItemAtIndex (SwipeView swipeView, int index);
	}
}

